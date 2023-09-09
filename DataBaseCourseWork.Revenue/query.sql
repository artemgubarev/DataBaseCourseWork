WITH SalesRevenue AS (
    SELECT
        w.ShopId,
        p.Name AS ProductName,
        SUM(s.Quantity) AS TotalQuantity,
        SUM((s.Price - ps.Price) * s.Quantity) AS TotalRevenue
    FROM
        Sales s
    INNER JOIN
        Workers w ON s.WorkerId = w.Id
    INNER JOIN
        ProductsInStock ps ON s.ProductId = ps.ProductId
    INNER JOIN
        Products p ON s.ProductId = p.Id
    WHERE
        s.Quantity <= ps.Quantity
    GROUP BY
        w.ShopId, s.ProductId, p.Name
)
SELECT
    sh.name AS ShopName,
    sr.ProductName,
    sr.TotalQuantity,
    sr.TotalRevenue
FROM
    SalesRevenue sr
INNER JOIN
    Shops sh ON sr.ShopId = sh.Id;