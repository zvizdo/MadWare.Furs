# MadWare.Furs
C# library for simplified communication with FURS (Finančna uprava Republike Slovenije).

## How to get started

First you have to set up the request data.

### Registering business premise request

```C#
var bp = new BusinessPremiseRequestBody
{
    BusinessPremiseRequest = new BusinessPremiseRequest
    {
        Header = new Header
        {
            MessageID = Guid.NewGuid().ToString(),
            DateTime = DateTime.Now
        },
        BusinessPremise = new BusinessPremise
        {
            TaxNumber = "12345678", //must be the same as in cert
            BusinessPremiseID = "MWTEST",
            BPIdentifier = new BPIdentifier
            {
                RealEstateBP = new RealEstateBP
                {
                    PropertyID = new PropertyID
                    {
                        BuildingNumber = 123,
                        BuildingSectionNumber = 12,
                        CadastralNumber = 1234
                    },
                    Address = new Address
                    {
                        HouseNumber = "123",
                        Street = "MS",
                        Community = "LJ",
                        City = "LJ",
                        PostalCode = "1000"
                    }
                }
            },
            ValidityDate = DateTime.Now.AddYears(1),
            SoftwareSupplier = new SoftwareSupplier
            {
                TaxNumber = "87654321"
            }
        }
    }
};
```

...or request for registering movable business premise...

```C#
var bp = new BusinessPremiseRequestBody
{
    BusinessPremiseRequest = new BusinessPremiseRequest
    {
        Header = new Header
        {
            MessageID = Guid.NewGuid().ToString(),
            DateTime = DateTime.Now
        },
        BusinessPremise = new BusinessPremise
        {
            TaxNumber = "12345678", //must be the same as in cert
            BusinessPremiseID = "MWTEST",
            BPIdentifier = new BPIdentifier
            {
                PremiseType = BPIdentifier.PremiseTypeEnum.A
            },
            ValidityDate = DateTime.Now.AddYears(1),
            SoftwareSupplier = new SoftwareSupplier
            {
                TaxNumber = "87654321"
            }
        }
    }
};
```

### Invoice request

```C#
var inv = new InvoiceRequestBody
{
    InvoiceRequest = new InvoiceRequest
    {
        Header = new Header
        {
            MessageID = Guid.NewGuid().ToString(),
            DateTime = DateTime.Now
        },
        Invoice = new Invoice
        {
            TaxNumber = "10442529",
            IssueDateTime = DateTime.Now,
            NumberingStructure = NumberingStructureEnum.B,
            InvoiceIdentifier = new InvoiceIdentifier
            {
                BusinessPremiseID = "MWTEST",
                ElectronicDeviceID = "SRV1",
                InvoiceNumber = 1
            },
            InvoiceAmount = 60.01M,
            PaymentAmount = 80.00M,
            TaxesPerSeller = new List<TaxesPerSeller>
            {
                new TaxesPerSeller
                {
                    VAT = new List<VAT>
                    {
                        new VAT
                        {
                            TaxRate = 22.00M,
                            TaxableAmount = 60.00M,
                            TaxAmount = 20.00M
                        }
                    }
                }
            },
            OperatorTaxNumber = "10442529"
        }
    }
};
```

...or sales book invoice request...

```C#
var inv = new InvoiceRequestBody
{
    InvoiceRequest = new InvoiceRequest
    {
        Header = new Header
        {
            MessageID = Guid.NewGuid().ToString(),
            DateTime = DateTime.Now
        },
        SalesBookInvoice = new SalesBookInvoice
        {
            TaxNumber = "10442529",
            IssueDate = DateTime.Now,
            SalesBookIdentifier = new SalesBookIdentifier
            {
                InvoiceNumber = "612",
                SetNumber = "03",
                SerialNumber = "5001-0001018"
            },
            BusinessPremiseID = "MWTEST",
            InvoiceAmount = 1234.56M,
            ReturnsAmount = 12.30M,
            PaymentAmount = 1047.76M,
            TaxesPerSeller = new List<TaxesPerSeller>
            {
                new TaxesPerSeller
                {
                    VAT = new List<.VAT>
                    {
                        new Invoice.VAT
                        {
                            TaxRate = 22.00M,
                            TaxableAmount = 36.89M,
                            TaxAmount = 8.12M
                        },
                        new Models.Invoice.VAT
                        {
                            TaxRate = 9.50M,
                            TaxableAmount = 56.53M,
                            TaxAmount = 5.37M
                        }
                    },
                    OtherTaxesAmount = 53.89M
                },
                new TaxesPerSeller
                {
                    SellerTaxNumber = "82730341",
                    VAT = new List<VAT>
                    {
                        new VAT
                        {
                            TaxRate = 22.00M,
                            TaxableAmount = 36.89M,
                            TaxAmount = 8.12M
                        },
                        new VAT
                        {
                            TaxRate = 9.50M,
                            TaxableAmount = 56.53M,
                            TaxAmount = 5.37M
                        }
                    }
                }
            }
        }
    }
};
```

When building request object note that all properties are documented from the offcial documentation.
Intelisense should provide additional explanation of what each property is used for.

A request is first validated before it is send to ensure the correctness of the data.
However, it is still strongly advised that the official documentation is read.

## Sending the request

Client is set up this way:

```C#
var c = new FursConfig 
{ 
  Url = url, //test or production url given by Furs 
  Certificate = cert //X509Certificate2 object which holds the certificate
};
//initializing the client
var client = new XmlFursWebService(c);
```

Sending business premise request is done like this:
```C#
var bpResponse = await client.SendRequest<BusinessPremiseResponseBody>(bpRequest);

//checking if an error occured
if( bpResponse.IsErrorResponse() ){
  throw new Exception(bpResponse.BusinessPremiseResponse.Error.ErrorMessage);
}
```
Sending invoice request is very similar:
```C#
var invResponse = await client.SendRequest<InvoiceResponseBody>(invRequest);

//checking if an error occured
if( invResponse.IsErrorResponse() ){
  throw new Exception(invResponse.InvoiceResponse.Error.ErrorMessage);
}

//getting UniqueInvoiceID or EOR
string eor = invResponse.InvoiceResponse.UniqueInvoiceID;

//getting ZOI - only if it is invoice request ( but not sales book invoice request )
string zoi = bpRequest.InvoiceRequest.Invoice.ProtectedID;
```

## To-Do

* the library is currently in beta thus it should and will be extensively tested before version 1.0.0 is released.
* Adding support for QRCode generation
* Write more and better unit tests
* Make better documentation and examples

All contributors are welcome.

## Contact
* Twitter [@zvizdo](https://twitter.com/zvizdo)

