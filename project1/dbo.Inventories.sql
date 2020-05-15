CREATE TABLE [dbo].[Inventories] (
    [InventoryID]       INT IDENTITY (1, 1) NOT NULL,
    [StoreID]           INT NULL,
    [ProductsProductID] INT NULL,
    [ProductQuantity]   INT NOT NULL,
    CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED ([InventoryID] ASC),
    CONSTRAINT [FK_Inventories_Products_ProductsProductID] FOREIGN KEY ([ProductsProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    CONSTRAINT [FK_Inventories_Stores_StoreID] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Stores] ([StoreID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Inventories_ProductsProductID]
    ON [dbo].[Inventories]([ProductsProductID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Inventories_StoreID]
    ON [dbo].[Inventories]([StoreID] ASC);

