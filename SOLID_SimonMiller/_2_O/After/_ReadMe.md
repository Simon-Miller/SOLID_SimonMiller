# Please note

StandardInvoiceValue also implements IInvoiceAmount, and therefore all new classes (record class) representing the discounted value implement the same interface.

The standard view of being open to extension implies inheritance, which is the mechanism I employed here.
But just as easily, they didn't have to inherit the same base class, but implement the same interface only.