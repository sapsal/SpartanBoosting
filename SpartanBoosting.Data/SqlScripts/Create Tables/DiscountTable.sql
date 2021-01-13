CREATE TABLE Discount (
    Id int  NOT NULL IDENTITY (1,1),
    DiscountCode varchar(255) not null,
    SingleUse bit not null default (0),
	DiscountPercentage int not null,
    InUse bit not null default (0)
	    CONSTRAINT [PK_Discount] PRIMARY KEY ([Id]),
);

ALTER TABLE PurchaseForm
ADD Discount int NULL
FOREIGN KEY (Discount) REFERENCES Discount(ID);

ALTER TABLE Discount ADD InUse bit not null default (0)