CREATE TABLE CarRecoveries (
    -- Unique ID for each recovery entry
    RecoveryID INT IDENTITY(1,1) PRIMARY KEY,
    
    -- The Number Plate will be used as the 'Key' in our Binary Search Tree
    NumberPlate VARCHAR(15) NOT NULL,
    
    -- Car and Customer Details
    CarModel VARCHAR(50) NOT NULL,
    CustomerName VARCHAR(100),
    
    -- Information about the breakdown
    IssueDescription TEXT,
    BreakdownLocation VARCHAR(255) NOT NULL,
    
    -- Time and Date of the incident
    BreakdownDateTime DATETIME DEFAULT GETDATE(),
    
    -- Current progress of the recovery
    Status VARCHAR(20) DEFAULT 'Pending' -- Pending, In Progress, Completed
);

-- Example search query that C# program will use
-- SELECT * FROM CarRecoveries WHERE NumberPlate = 'ABC1234';
