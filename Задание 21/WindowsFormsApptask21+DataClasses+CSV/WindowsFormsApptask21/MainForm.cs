using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApptask21.Classes; //подключение файла DataClasses с нужными классами



namespace WindowsFormsApptask21
{
    public partial class MainForm : Form
    {
        private Dictionary<int, int> originalStocks = new Dictionary<int, int>();
        private List<Product> products = new List<Product>();
        private List<Client> clients = new List<Client>();
        private List<Sale> sales = new List<Sale>();
        private List<SaleItem> saleItems = new List<SaleItem>();
        private List<CartItem> cart = new List<CartItem>();

        public MainForm()
        {
            InitializeComponent();
            LoadDataFromCSV();
            FillComboBox();
            UpdateCartButtons();
            this.FormClosing += MainForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen; // Центрировать на экране
            this.WindowState = FormWindowState.Normal; // Нормальное состояние
            this.MinimumSize = new Size(900, 600); // Минимальный размер
            this.MaximizeBox = true; // Разрешить развертывание
            this.MinimizeBox = true; // Разрешить сворачивание
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Сбрасываем остатки при закрытии формы
            ResetStocks();
        }
        private void LoadDataFromCSV()
        {
            // Получаем путь к исполняемому файлу
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string csvFolder = Path.Combine(appPath, "CSV");

            // Проверяем существование папки CSV
            if (!Directory.Exists(csvFolder))
            {
                MessageBox.Show($"Папка CSV не найдена по пути:\n{csvFolder}\n\n" +
                              "Пожалуйста, создайте папку CSV и добавьте файлы:\n" +
                              "1. Products.csv\n2. Clients.csv\n3. Sales.csv\n4. SaleItems.csv",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Загружаем данные из CSV
            LoadFromCSV(csvFolder);

            // Проверяем, загрузились ли данные
            if (products.Count == 0)
            {
                MessageBox.Show($"Не удалось загрузить данные.\n" +
                              "Проверьте наличие и формат файла Products.csv в папке:\n" +
                              csvFolder, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Показываем информацию о загруженных данных
                string info = $"Загружено:\n" +
                             $"• Товаров: {products.Count}\n" +
                             $"• Продаж: {sales.Count}\n" +
                             $"• Позиций продаж: {saleItems.Count}";

                MessageBox.Show(info, "Данные загружены",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadFromCSV(string csvFolder)
        {
            try
            {
                // Загружаем продукты
                string productsFile = Path.Combine(csvFolder, "Products.csv");
                if (File.Exists(productsFile))
                {
                    var lines = File.ReadAllLines(productsFile);
                    for (int i = 1; i < lines.Length; i++) // Пропускаем заголовок
                    {
                        var parts = lines[i].Split(';');
                        if (parts.Length >= 5)
                        {
                            int id = int.Parse(parts[0]);
                            int stock = int.Parse(parts[4]);

                            products.Add(new Product
                            {
                                Id = id,
                                Name = parts[1],
                                Manufacturer = parts[2],
                                Price = decimal.Parse(parts[3]),
                                Stock = stock
                            });

                            // Сохраняем исходный остаток в словарь
                            originalStocks[id] = stock;
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Файл Products.csv не найден в папке:\n{csvFolder}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Загружаем продажи
                string salesFile = Path.Combine(csvFolder, "Sales.csv");
                if (File.Exists(salesFile))
                {
                    var lines = File.ReadAllLines(salesFile);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var parts = lines[i].Split(';');
                        if (parts.Length >= 5)
                        {
                            sales.Add(new Sale
                            {
                                Id = int.Parse(parts[0]),
                                ClientId = int.Parse(parts[1]),
                                Date = DateTime.Parse(parts[2]),
                                Total = decimal.Parse(parts[3]),
                                Discount = decimal.Parse(parts[4])
                            });
                        }
                    }
                }

                // Загружаем позиции продаж
                string saleItemsFile = Path.Combine(csvFolder, "SaleItems.csv");
                if (File.Exists(saleItemsFile))
                {
                    var lines = File.ReadAllLines(saleItemsFile);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var parts = lines[i].Split(';');
                        if (parts.Length >= 4)
                        {
                            saleItems.Add(new SaleItem
                            {
                                SaleId = int.Parse(parts[0]),
                                ProductId = int.Parse(parts[1]),
                                Quantity = int.Parse(parts[2]),
                                PricePerUnit = decimal.Parse(parts[3])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки CSV: " + ex.Message +
                              "\n\nПроверьте:\n1. Формат файлов (разделитель ;)\n" +
                              "2. Кодировку (UTF-8)\n3. Корректность данных\n" +
                              "4. Наличие всех требуемых файлов",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillComboBox()
        {
            comboBoxQueries.Items.AddRange(new object[]
            {
                "1. Весь товар с ценами",
                "2. Поиск по названию",
                "3. Поиск по производителю",
                "4. Показать корзину",
                "5. Подбор по бюджету",
                "6. Рассчитать чек",
                "7. Продажи по товару",
                "8. Продажи за период"
            });
            comboBoxQueries.SelectedIndex = 0;
        }
        // Метод для восстановления исходных остатков товаров
        private void ResetStocks()
        {
            foreach (var product in products)
            {
                if (originalStocks.ContainsKey(product.Id))
                {
                    product.Stock = originalStocks[product.Id];
                }
            }

            // Очищаем корзину, так как остатки сброшены
            cart.Clear();
        }



        // ==================== МЕТОДЫ РАБОТЫ С КОРЗИНОЙ ====================

        private void AddToCart(int productId, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                // Проверяем, достаточно ли товара на складе
                if (product.Stock <= 0)
                {
                    MessageBox.Show($"Товар '{product.Name}' отсутствует на складе",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, запрашиваемое количество не превышает остаток
                if (quantity > product.Stock)
                {
                    MessageBox.Show($"Недостаточно товара на складе. Доступно: {product.Stock} шт.",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Находим товар в корзине
                var existingItem = cart.FirstOrDefault(cartItem => cartItem.Product.Id == productId);
                if (existingItem != null)
                {
                    // Проверяем, чтобы общее количество в корзине не превышало остаток
                    int totalInCart = existingItem.Quantity + quantity;
                    if (totalInCart > product.Stock)
                    {
                        MessageBox.Show($"Нельзя добавить {quantity} шт. В корзине уже {existingItem.Quantity} шт., всего на складе {product.Stock} шт.",
                                      "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    existingItem.Quantity += quantity;
                }
                else
                {
                    cart.Add(new CartItem { Product = product, Quantity = quantity });
                }

                // Уменьшаем остаток товара на складе
                product.Stock -= quantity;

                MessageBox.Show($"Добавлено в корзину: {product.Name} x{quantity}\n" +
                               $"Остаток на складе: {product.Stock} шт.",
                              "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Обновляем отображение, если показывается список товаров
                if (comboBoxQueries.SelectedIndex == 0)
                {
                    ShowAllProducts();
                }
            }
            else
            {
                MessageBox.Show("Товар не найден", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveFromCart(int productId)
        {
            var cartItem = cart.FirstOrDefault(ci => ci.Product.Id == productId);
            if (cartItem != null)
            {
                int removeQuantity = (int)numericUpDownQuantity.Value;

                // Проверяем, что запрашиваемое количество для удаления не больше, чем в корзине
                if (removeQuantity > cartItem.Quantity)
                {
                    MessageBox.Show($"В корзине только {cartItem.Quantity} шт. этого товара",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Увеличиваем остаток на складе
                var product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    product.Stock += removeQuantity;
                }

                // Уменьшаем количество в корзине или удаляем товар полностью
                if (removeQuantity == cartItem.Quantity)
                {
                    cart.Remove(cartItem);
                    MessageBox.Show($"Товар '{cartItem.Product.Name}' полностью удален из корзины",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cartItem.Quantity -= removeQuantity;
                    MessageBox.Show($"Удалено из корзины: {cartItem.Product.Name} x{removeQuantity}\n" +
                                   $"Осталось в корзине: {cartItem.Quantity} шт.",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Обновляем отображение
                if (comboBoxQueries.SelectedIndex == 0)
                {
                    ShowAllProducts();
                }
            }
            else
            {
                MessageBox.Show("Товар не найден в корзине", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCart()
        {
            if (cart.Count > 0)
            {
                // Возвращаем все товары на склад
                foreach (var cartItem in cart)
                {
                    var product = products.FirstOrDefault(p => p.Id == cartItem.Product.Id);
                    if (product != null)
                    {
                        product.Stock += cartItem.Quantity;
                    }
                }
            }

            cart.Clear();
            MessageBox.Show("Корзина очищена. Все товары возвращены на склад.",
                          "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                if (selectedRow.Cells["ID"] != null && selectedRow.Cells["ID"].Value != null)
                {
                    int productId = (int)selectedRow.Cells["ID"].Value;
                    int quantity = (int)numericUpDownQuantity.Value;

                    // Проверяем, что количество больше 0
                    if (quantity <= 0)
                    {
                        MessageBox.Show("Количество должно быть больше 0", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    AddToCart(productId, quantity);

                    if (comboBoxQueries.SelectedIndex == 3)
                    {
                        ShowCart();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар из таблицы", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 && comboBoxQueries.SelectedIndex == 3)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                var selectedItem = selectedRow.DataBoundItem as CartItem;
                if (selectedItem != null)
                {
                    RemoveFromCart(selectedItem.Product.Id);
                    ShowCart();
                }
            }
            else
            {
                MessageBox.Show("Выберите товар из корзины для удаления", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonClearCart_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Корзина уже пуста", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Показываем диалог подтверждения
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите очистить корзину?\n\n" +
                $"В корзине сейчас: {cart.Count} товаров на сумму {cart.Sum(item => item.TotalPrice):C}",
                "Подтверждение очистки корзины",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2); // По умолчанию выбираем "Нет"

            // Если пользователь выбрал "Да"
            if (result == DialogResult.Yes)
            {
                ClearCart();
                if (comboBoxQueries.SelectedIndex == 3)
                {
                    ShowCart();
                }
            }
            // Если пользователь выбрал "Нет" - ничего не делаем
        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Логика при выборе строки
        }

        private void UpdateCartButtons()
        {
            buttonAddToCart.Enabled = comboBoxQueries.SelectedIndex < 3 && products.Count > 0;
            buttonRemoveFromCart.Enabled = comboBoxQueries.SelectedIndex == 3 && cart.Count > 0;
        }

        // ==================== ОСНОВНЫЕ ЗАПРОСЫ LINQ ====================

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (products.Count == 0)
                {
                    MessageBox.Show("Данные не загружены из CSV файлов.", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UpdateCartButtons();

                switch (comboBoxQueries.SelectedIndex)
                {
                    case 0: ShowAllProducts(); break;
                    case 1: SearchByName(); break;
                    case 2: SearchByManufacturer(); break;
                    case 3: ShowCart(); break;
                    case 4: FilterByBudget(); break;
                    case 5: CalculateWithDiscount(); break;
                    case 6: ShowSalesByProduct(); break;
                    case 7: ShowSalesByPeriod(); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 1. Весь товар с ценами
        private void ShowAllProducts()
        {
            dataGridView.DataSource = products.Select(p => new
            {
                ID = p.Id,
                Наименование = p.Name,
                Производитель = p.Manufacturer,
                Цена = string.Format("{0:C}", p.Price),
                Наличие = p.Stock,
                Статус = p.Stock > 0 ? "В наличии" : "Нет в наличии"
            }).ToList();

            labelTotal.Text = "Всего товаров: " + products.Count +
                             " | В наличии: " + products.Count(p => p.Stock > 0);
        }

        // 2. Поиск по названию
        private void SearchByName()
        {
            string keyword = textBoxFilter.Text;
            if (string.IsNullOrEmpty(keyword) || keyword.Trim() == "")
            {
                MessageBox.Show("Введите фрагмент названия", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                .Select(p => new
                {
                    ID = p.Id,
                    Наименование = p.Name,
                    Производитель = p.Manufacturer,
                    Цена = string.Format("{0:C}", p.Price)
                }).ToList();

            dataGridView.DataSource = result;
            labelTotal.Text = "Найдено товаров: " + result.Count;
        }

        // 3. Поиск по производителю
        private void SearchByManufacturer()
        {
            string keyword = textBoxFilter.Text;
            if (string.IsNullOrEmpty(keyword) || keyword.Trim() == "")
            {
                MessageBox.Show("Введите фрагмент производителя", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = products
                .Where(p => p.Manufacturer.ToLower().Contains(keyword.ToLower()))
                .Select(p => new
                {
                    ID = p.Id,
                    Наименование = p.Name,
                    Производитель = p.Manufacturer,
                    Цена = string.Format("{0:C}", p.Price)
                }).ToList();

            dataGridView.DataSource = result;
            labelTotal.Text = "Найдено товаров: " + result.Count;
        }

        // 4. Корзина покупок
        private void ShowCart()
        {
            if (cart.Count == 0)
            {
                dataGridView.DataSource = null;
                labelTotal.Text = "Корзина пуста";
            }
            else
            {
                dataGridView.DataSource = cart;
                decimal total = cart.Sum(item => item.TotalPrice);
                int totalQuantity = cart.Sum(item => item.Quantity);

                labelTotal.Text = string.Format("Итого в корзине: {0:C} ({1} шт.)", total, totalQuantity);
            }
        }

        // 5. Подбор по бюджету
        private void FilterByBudget()
        {
            if (decimal.TryParse(textBoxFilter.Text, out decimal budget))
            {
                var result = products
                    .Where(p => p.Price <= budget)
                    .OrderByDescending(p => p.Price)
                    .Select(p => new
                    {
                        ID = p.Id,
                        Наименование = p.Name,
                        Цена = string.Format("{0:C}", p.Price),
                        Остаток = p.Stock
                    }).ToList();

                dataGridView.DataSource = result;
                labelTotal.Text = string.Format("Найдено товаров в пределах {0:C}: {1}", budget, result.Count);
            }
            else
            {
                MessageBox.Show("Введите корректную сумму", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. Чек со скидкой
        private void CalculateWithDiscount()
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Корзина пуста. Добавьте товары в корзину.",
                              "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = cart.Sum(item => item.TotalPrice);
            decimal discount = 0;

            if (checkBoxRegular.Checked)
                discount = total * 0.1m;

            if (total > 50000)
            {
                decimal extraDiscount = total * 0.15m;
                if (extraDiscount > discount)
                    discount = extraDiscount;
            }

            dataGridView.DataSource = cart;
            labelTotal.Text = string.Format("Итого: {0:C} | Скидка: {1:C} | К оплате: {2:C}",
                                           total, discount, total - discount);
        }

        // 7. Продажи по товару ЗА ПЕРИОД
        private void ShowSalesByProduct()
        {
            int productId = (int)numericUpDownProductId.Value;

            // Получаем период из календаря
            DateTime from = monthCalendar.SelectionStart;
            DateTime to = monthCalendar.SelectionEnd;

            if (!products.Any(p => p.Id == productId))
            {
                MessageBox.Show($"Товар с ID {productId} не найден", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var query = saleItems
                .Where(si => si.ProductId == productId)
                .Join(sales, si => si.SaleId, s => s.Id, (si, s) => new { si, s })
                .Where(x => x.s.Date >= from && x.s.Date <= to)
                .Join(products, x => x.si.ProductId, p => p.Id, (x, p) => new { x.si, x.s, p });

            var filtered = query.Select(x => new
            {
                Дата = x.s.Date.ToString("dd.MM.yyyy"),
                Товар = x.p.Name,
                Количество = x.si.Quantity,
                Цена = string.Format("{0:C}", x.si.PricePerUnit),
                Сумма = string.Format("{0:C}", x.si.Quantity * x.si.PricePerUnit),
                Скидка = string.Format("{0:C}", x.s.Discount)
            }).ToList();

            dataGridView.DataSource = filtered;

            if (filtered.Count > 0)
            {
                int totalQuantity = filtered.Sum(x => x.Количество);
                decimal totalAmount = filtered.Sum(x => decimal.Parse(x.Сумма.Replace("$", "").Replace("₽", "").Trim()));

                labelTotal.Text = string.Format("Продажи товара ID {0} за период {1:dd.MM.yyyy} - {2:dd.MM.yyyy}: {3} шт., на сумму {4:C}",
                                               productId, from, to, totalQuantity, totalAmount);
            }
            else
            {
                labelTotal.Text = string.Format("Продажи товара ID {0} за период {1:dd.MM.yyyy} - {2:dd.MM.yyyy} не найдены",
                                               productId, from, to);
            }
        }

        // 8. Продажи за период (ВСЕ продажи за период)
        private void ShowSalesByPeriod()
        {
            DateTime from = monthCalendar.SelectionStart;
            DateTime to = monthCalendar.SelectionEnd;

            // Проверяем, что выбран корректный период
            if (from > to)
            {
                MessageBox.Show("Дата 'с' не может быть позже даты 'по'", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем все продажи за период
            var periodSales = sales
                .Where(s => s.Date >= from && s.Date <= to)
                .OrderBy(s => s.Date)
                .ToList();

            if (periodSales.Count == 0)
            {
                dataGridView.DataSource = null;
                labelTotal.Text = string.Format("Продаж за период {0:dd.MM.yyyy} - {1:dd.MM.yyyy} не найдено",
                                               from, to);
                return;
            }

            // Группируем продажи по дате для отчета
            var report = periodSales
                .Select(s => new
                {
                    ID_продажи = s.Id,
                    Дата = s.Date.ToString("dd.MM.yyyy"),
                    ID_клиента = s.ClientId,
                    Клиент = clients.FirstOrDefault(c => c.Id == s.ClientId)?.Name ?? "Неизвестный",
                    Сумма = string.Format("{0:C}", s.Total),
                    Скидка = string.Format("{0:C}", s.Discount),
                    К_оплате = string.Format("{0:C}", s.Total - s.Discount)
                })
                .ToList();

            dataGridView.DataSource = report;

            decimal totalSales = periodSales.Sum(s => s.Total);
            decimal totalDiscount = periodSales.Sum(s => s.Discount);
            decimal totalToPay = totalSales - totalDiscount;

            labelTotal.Text = string.Format("Продажи за период {0:dd.MM.yyyy} - {1:dd.MM.yyyy}: {2} продаж\n" +
                                           "Общая сумма: {3:C} | Скидки: {4:C} | К оплате: {5:C}",
                                           from, to, periodSales.Count,
                                           totalSales, totalDiscount, totalToPay);
        }

        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}