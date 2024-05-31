public class CustomerAddressClass
{
    public CustomerAddressClass(string? companyName, string? address1, string? cityAndProvince, string? postalCode)
    {
        CompanyName = companyName?.Trim();
        Address1 = address1?.Trim();
        CityAndProvince = cityAndProvince?.Trim();
        PostalCode = ValidatePostalCode(postalCode);
    }
    private string? ValidatePostalCode(string? postalCode)
    {
        if (!string.IsNullOrEmpty(postalCode?.Trim()))
        {
            postalCode = postalCode.Trim();
            if (postalCode.Length == 7 && postalCode[3] == ' ') return postalCode;
            else return postalCode.Substring(0, 3) + " " + postalCode.Substring(3, 3); 
        }
        return "";
    }
    public string? CompanyName { get; set; }
    public string? Address1 { get; set; }
    public string? CityAndProvince { get; set; }
    public string? PostalCode { get; set; }
}

public class PhoneNumberClass
{
    public PhoneNumberClass(string? work, string? cell)
    {
        Work = work?.Trim();
        Cell = cell?.Trim();
    }
    public string? Work { get; set; }
    public string? Cell { get; set; }
}

public class EquipmentSetClass
{
    public EquipmentSetClass(string? equipmentName, string? make, string? model, string? serialNo, string? unitLocation)
    {
        EquipmentName = equipmentName?.ToUpper()?.Trim();
        Make = make?.ToUpper()?.Trim();
        Model = model?.ToUpper()?.Trim();
        SerialNo = serialNo?.ToUpper()?.Trim();
        UnitLocation = unitLocation?.ToUpper()?.Trim();
    }
    public string? EquipmentName { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public string? UnitLocation { get; set; }
}
public class EquipmentsClass
{
    public EquipmentSetClass? Set1 { get; set; }
    public EquipmentSetClass? Set2 { get; set; }
    public EquipmentSetClass? Set3 { get; set; }
    public EquipmentSetClass? Set4 { get; set; }
    public EquipmentSetClass? Set5 { get; set; }
}
public class RefrigerantRClass
{
    public RefrigerantRClass(string? unit, string? qty, string? type)
    {
        Unit = unit?.Trim();
        QTY = qty?.Trim();
        Type_ = type?.Trim();
    }
    public string? Unit { get; set; }
    public string? QTY { get; set; }
    public string? Type_ { get; set; }
}

public class PresetClass
{
    public PresetClass(RefrigerantRClass? refrigerantR, string? environmentalCharge, string? rentalOfEquipment, string? shopSupply, string? warrantyHDGCharge)
    {
        RefrigerantR = refrigerantR;
        EnvironmentalCharge = environmentalCharge?.Trim();
        RentalOfEquipment = rentalOfEquipment?.Trim();
        ShopSupply = shopSupply?.Trim();
        WarrantyHDGCharge = warrantyHDGCharge?.Trim();
    }
    public RefrigerantRClass? RefrigerantR { get; set; }
    public string? EnvironmentalCharge { get; set; }
    public string? RentalOfEquipment { get; set; }
    public string? ShopSupply { get; set; }
    public string? WarrantyHDGCharge { get; set; }
}

public class CO2N2Class
{
    public CO2N2Class(bool? used, string? qty, string? partNo, string? whol, string? ts, string? shop)
    {
        Used = used;
        QTY = qty?.Trim();
        PartNo = partNo?.Trim();
        Whol = whol?.Trim();
        TS = ts?.Trim();
        Shop = shop?.Trim();
    }
    public bool? Used { get; set; }
    public string? QTY { get; set; }
    public string? PartNo { get; set; }
    public string? Whol { get; set; }
    public string? TS { get; set; }
    public string? Shop { get; set; }
}

public class MaterialsItemClass
{
    public MaterialsItemClass(string? materialUsed, string? qty, string? partNo, bool whol, bool ts, bool shop, float? price)
    {
        MaterialUsed = materialUsed?.Trim();
        QTY = qty?.Trim();
        PartNo = partNo?.Trim();
        Whol = whol;
        TS = ts;
        Shop = shop;
        Price = price;
    }
    public string? MaterialUsed { get; set; }
    public string? QTY { get; set; }
    public string? PartNo { get; set; }
    public bool Whol { get; set; }
    public bool TS { get; set; }
    public bool Shop { get; set; }
    public float? Price { get; set; }
}

public class OtherClass
{
    public CO2N2Class? CO2 { get; set; }
    public CO2N2Class? N2 { get; set; }
    public MaterialsItemClass? Item3 { get; set; }
    public MaterialsItemClass? Item4 { get; set; }
    public MaterialsItemClass? Item5 { get; set; }
    public MaterialsItemClass? Item6 { get; set; }
    public MaterialsItemClass? Item7 { get; set; }
    public MaterialsItemClass? Item8 { get; set; }
    public MaterialsItemClass? Item9 { get; set; }
    public MaterialsItemClass? Item10 { get; set; }
    public MaterialsItemClass? Item11 { get; set; }
    public MaterialsItemClass? Item12 { get; set; }
    public MaterialsItemClass? Item13 { get; set; }
    public MaterialsItemClass? Item14 { get; set; }
    public MaterialsItemClass? Item15 { get; set; }
}

public class MaterialsClass
{
    public PresetClass? Preset { get; set; }
    public OtherClass? Other { get; set; }
}
public class TechSetClass
{
    public TechSetClass(string? name, string? regHr, string? afterHr, string? travelHr, int? _in, int? _out, float? hours)
    {
        Name = name?.Trim();
        RegHr = regHr?.Trim();
        AfterHr = afterHr?.Trim();
        TravelHr = travelHr?.Trim();
        In = _in;
        Out = _out;
        Hours = hours;
    }
    public string? Name { get; set; }
    public string? RegHr { get; set; }
    public string? AfterHr { get; set; }
    public string? TravelHr { get; set; }
    public int? In { get; set; }
    public int? Out { get; set; }
    public float? Hours { get; set; }
}

public class HourClass
{
    public TechSetClass? Tech1 { get; set; }
    public TechSetClass? Tech2 { get; set; }
    public TechSetClass? Tech3 { get; set; }
}

public class PaymentSetClass
{
    public PaymentSetClass(string? note, float? price)
    {
        Note = note?.Trim();
        Price = price;
    }
    public string? Note { get; set; }
    public float? Price { get; set; }
}

public class PaymentClass
{
    public float? TotalHr { get; set; }
    public float? PerHr { get; set; }
    public float? TotalHrPrice { get; set; }
    public PaymentSetClass? Material { get; set; }
    public PaymentSetClass? ServiceVan { get; set; }
    public PaymentSetClass? SubTotal { get; set; }
    public PaymentSetClass? GST { get; set; }
    public PaymentSetClass? PST { get; set; }
    public PaymentSetClass? TotalDue { get; set; }
}

public class ServiceReport
{
    public ServiceReport(
        string? key,
        CustomerAddressClass? customerAddress,
        string? personCalling,
        PhoneNumberClass? phoneNumber,
        string? serv,
        string? poNo,
        EquipmentsClass? equipments,
        string? timeOfCall,
        string? dateOfService,
        string? dateOfComp,
        bool completed,
        bool boParts,
        string? typeOfService,
        string? customerComplaint,
        string? servicesRendered,
        string? remarksAndRecommendations,
        MaterialsClass? materials,
        HourClass? hour,
        PaymentClass? payment)
    {
        Key = key?.Trim();
        CustomerAddress = customerAddress;
        PersonCalling = personCalling?.Trim();
        PhoneNumber = phoneNumber;
        Serv = serv?.Trim();
        PONo = poNo?.Trim();
        Equipments = equipments;
        TimeOfCall = timeOfCall;
        DateOfService = dateOfService?.Trim();
        DateOfComp = dateOfComp?.Trim();
        Completed = completed;
        BOParts = boParts;
        TypeOfService = typeOfService?.ToUpper()?.Trim();
        CustomerComplaint = customerComplaint?.Trim();
        ServicesRendered = servicesRendered?.Trim();
        RemarksAndRecommendations = remarksAndRecommendations?.Trim();
        Materials = materials;
        Hour = hour;
        Payment = payment;
    }
    public string? Key { get; set; }
    public CustomerAddressClass? CustomerAddress { get; set; }
    public string? PersonCalling { get; set; }
    public PhoneNumberClass? PhoneNumber { get; set; }
    public string? Serv { get; set; }
    public string? PONo { get; set; }
    public EquipmentsClass? Equipments { get; set; }
    public string? TimeOfCall { get; set; }
    public string? DateOfService { get; set; }
    public string? DateOfComp { get; set; }
    public bool Completed { get; set; }
    public bool BOParts { get; set; }
    public string? TypeOfService { get; set; }
    public string? CustomerComplaint { get; set; }
    public string? ServicesRendered { get; set; }
    public string? RemarksAndRecommendations { get; set; }
    public MaterialsClass? Materials { get; set; }
    public HourClass? Hour { get; set; }
    public PaymentClass? Payment { get; set; }
}

