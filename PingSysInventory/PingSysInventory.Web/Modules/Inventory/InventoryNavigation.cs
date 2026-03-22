using Inventory = PingSysInventory.Inventory.Pages;

[assembly: NavigationMenu(5000, "Inventory", icon: "fa-cubes")]
[assembly: NavigationLink(5100, "Inventory/Categories", typeof(Inventory.CategoriesPage), icon: "fa-folder")]
[assembly: NavigationLink(5200, "Inventory/Products", typeof(Inventory.ProductsPage), icon: "fa-barcode")]
[assembly: NavigationLink(5300, "Inventory/Stock Movements", typeof(Inventory.StockMovementsPage), icon: "fa-exchange")]
