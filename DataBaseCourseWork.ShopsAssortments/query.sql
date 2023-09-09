WITH OrdersWithQuantity AS (
    SELECT
        O.Id AS OrderId,
        O.ShopId,
        O.ProviderId,
        PO.ProductId,
        PO.Quantity AS RequestedQuantity
    FROM
        Orders O
    INNER JOIN
        ProductsInOrders PO ON O.Id = PO.OrderId
),
SuppliesWithQuantity AS (
    SELECT
        S.Id AS SupplyId,
        S.ShopId,
        S.ProviderId,
        PS.ProductId,
        PS.Quantity AS DeliveredQuantity
    FROM
        Supplies S
    INNER JOIN
        ProductsInSupplies PS ON S.Id = PS.SupplyId
),
Stock AS (
    SELECT
        PS.ProductId,
        SUM(PS.Quantity) AS AvailableQuantity
    FROM
        ProductsInStock PS
    GROUP BY
        PS.ProductId
)
SELECT
    S.Name AS Shop,
    P.Name AS Product,
    COALESCE(SUM(CASE
        WHEN ST.AvailableQuantity >= SW.DeliveredQuantity THEN SW.DeliveredQuantity
        ELSE ST.AvailableQuantity
    END), 0) AS QuantityInShop
FROM
    Shops S
LEFT JOIN
    OrdersWithQuantity OW ON S.Id = OW.ShopId
LEFT JOIN
    SuppliesWithQuantity SW ON S.Id = SW.ShopId
LEFT JOIN
    Stock ST ON SW.ProductId = ST.ProductId
LEFT JOIN
    Products P ON SW.ProductId = P.Id
GROUP BY
    S.Name, P.Name
HAVING
    COALESCE(SUM(CASE
        WHEN ST.AvailableQuantity >= SW.DeliveredQuantity THEN SW.DeliveredQuantity
        ELSE ST.AvailableQuantity
    END), 0) > 0
ORDER BY
    S.Name, P.Name;

