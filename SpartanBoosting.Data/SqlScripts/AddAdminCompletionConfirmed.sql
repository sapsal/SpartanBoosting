ALTER TABLE purchaseform 
ADD AdminCompletionConfirmed BIT NOT NULL
CONSTRAINT AdminCompletionConfirmedConstraint DEFAULT 0
WITH VALUES