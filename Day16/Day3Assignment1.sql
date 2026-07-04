IF OBJECT_ID('User_', 'U') IS NULL
BEGIN
    CREATE TABLE User_ (
        Id INT PRIMARY KEY,
        Username VARCHAR(50),
        Email VARCHAR(100),
        Age INT CHECK (Age > 18)
    );
END

INSERT INTO User_ VALUES
(1, 'Aryan', 'aryan@gmail.com', 21),
(2, 'Rahul', 'rahul@gmail.com', 28),
(3, 'Priya', 'priya@gmail.com', 24),
(4, 'Sneha', 'sneha@gmail.com', 32),
(5, 'Rohan', 'rohan@gmail.com', 27);

SELECT * FROM User_;
SELECT *
FROM User_
WHERE Age > (
    SELECT AVG(Age)
    FROM User_
);

SELECT *
FROM User_
WHERE Age IN (
    SELECT Age
    FROM User_
    WHERE Age > 25
);

SELECT CASE
    WHEN EXISTS (
        SELECT *
        FROM User_
        WHERE Age > 30
    )
    THEN 'Yes'
    ELSE 'No'
END AS Result;

SELECT U1.*
FROM Users U1
WHERE U1.Age > (
    SELECT AVG(U2.Age)
    FROM User_ U2
    WHERE U2.Id <> U1.Id
);

SELECT
    Id,
    Username,
    Age,
    (SELECT AVG(Age) FROM User_) AS Overall_Average_Age
FROM Users;
