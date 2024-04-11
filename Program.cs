using Newtonsoft.Json;

Console.WriteLine("Canadian Refrigeration & Air Conditioning Ltd.");
Console.WriteLine("JSON string: ");

string jsonString = "";
while (true)
{
    string currentString = Console.ReadLine() ?? "";
    if (currentString != "") jsonString = jsonString + currentString;
    else break;
}
Console.WriteLine("JSON string received.");

ServiceReport serviceReport = JsonConvert.DeserializeObject<ServiceReport>(jsonString)!;
Console.WriteLine("JSON string converted successfully.");
string jsonFilePath = $"C:\\Users\\Owner\\Downloads\\{serviceReport.Key}.json";
using (FileStream fs = File.Create(jsonFilePath)) Console.WriteLine($"File created: {jsonFilePath}");
using (StreamWriter writer = new StreamWriter(jsonFilePath)) writer.Write(jsonString);

string draftPath = $"C:\\Users\\Owner\\Downloads\\{serviceReport.Key} - draft.txt";
using (FileStream fs = File.Create(draftPath)) Console.WriteLine($"File created: {draftPath}");

using (StreamWriter writer = new StreamWriter(draftPath))
{
    writer.WriteLine($"Invoice: ");
    writer.WriteLine($"{serviceReport.CustomerAddress?.CompanyName}");
    writer.WriteLine($"{serviceReport.CustomerAddress?.Address1}, {serviceReport.CustomerAddress?.CityAndProvince}, {serviceReport.CustomerAddress?.PostalCode}");
    writer.WriteLine();

    WriteIfNotNull(writer, true, serviceReport.PONo, "Given PO #");
    WriteIfNotNull(writer, true, serviceReport.DateOfService, "Date of Service");
    WriteIfNotNull(writer, true, serviceReport.DateOfComp, "Date of Completion");
    WriteIfNotNull(writer, true, serviceReport.PersonCalling, "Contact Person");

    for (int i = 0; i < 3; i++) writer.WriteLine();

    writer.WriteLine($"Service Report: {serviceReport.Key}");
    writer.WriteLine();

    WriteEquipmentDetails(writer, 1, serviceReport.Equipments?.Set1);
    WriteEquipmentDetails(writer, 2, serviceReport.Equipments?.Set2);
    WriteEquipmentDetails(writer, 3, serviceReport.Equipments?.Set3);
    WriteEquipmentDetails(writer, 4, serviceReport.Equipments?.Set4);
    WriteEquipmentDetails(writer, 5, serviceReport.Equipments?.Set5);

    writer.WriteLine($"{serviceReport.TypeOfService}");
    for (int i = 0; i < serviceReport.ServicesRendered?.Count; i++) WriteIfNotNull(writer, true, serviceReport.ServicesRendered[i]);
    writer.WriteLine();

    writer.WriteLine($"Tech Services                                                                   {serviceReport.Payment?.TotalHrPrice:F2}");
    WriteMaterialDetails(writer, serviceReport.Materials);
    WritePaymentDetails(writer, serviceReport.Payment?.ServiceVan, "Service Van");
    WriteCustomPaymentDetails(writer, serviceReport.Payment?.CustomPayment1);
    WriteCustomPaymentDetails(writer, serviceReport.Payment?.CustomPayment2);
    WriteCustomPaymentDetails(writer, serviceReport.Payment?.CustomPayment3);
}

void WriteIfNotNull(StreamWriter writer, bool newLine, string? target, string? tag = "")
{
    if (!string.IsNullOrEmpty(target))
    {
        string formattedTarget = char.ToUpper(target[0]) + target.Substring(1);
        if (newLine) writer.WriteLine(string.IsNullOrEmpty(tag) ? $"{formattedTarget}" : $"{tag}: {formattedTarget}");
        else writer.Write(string.IsNullOrEmpty(tag) ? $"{formattedTarget}" : $"{tag}: {formattedTarget}");
    }
}

void WritePaymentDetails(StreamWriter writer, PaymentSetClass? paymentSet, string tag)
{
    if (paymentSet?.Price != null)
    {
        string temp = $"{tag}{(!string.IsNullOrEmpty(paymentSet?.Note) ? $" - {paymentSet.Note}" : "")}";
        writer.Write(temp);
        for (int i = 0; i < (80 - temp.Length); i++) writer.Write($" ");
        writer.WriteLine($"{paymentSet?.Price:F2}");
    }
}

void WriteCustomPaymentDetails(StreamWriter writer, CustomPaymentSetClass? customPaymentSet)
{
    if (!string.IsNullOrEmpty(customPaymentSet?.Payment) && customPaymentSet?.Price != null)
    {
        string temp = $"{customPaymentSet?.Payment}{(!string.IsNullOrEmpty(customPaymentSet?.Note) ? $" - {customPaymentSet.Note}" : "")}";
        writer.Write(temp);
        for (int i = 0; i < (80 - temp.Length); i++) writer.Write($" ");
        writer.WriteLine($"{customPaymentSet?.Price:F2}");
    }
}

void WriteEquipmentDetails(StreamWriter writer, int index, EquipmentSetClass? equipmentSet)
{
    if (equipmentSet != null && (!string.IsNullOrEmpty(equipmentSet.EquipmentName) || !string.IsNullOrEmpty(equipmentSet.Make) || !string.IsNullOrEmpty(equipmentSet.Model) || !string.IsNullOrEmpty(equipmentSet.SerialNo)))
    {
        writer.WriteLine($"{index}. {(string.IsNullOrEmpty(equipmentSet.Make) ? "" : equipmentSet.Make + " ")}{equipmentSet.EquipmentName}");
        writer.WriteLine($"MODEL: {equipmentSet.Model}");
        writer.WriteLine($"SERIAL #: {equipmentSet.SerialNo}");
        writer.WriteLine($"LOCATION: {equipmentSet.UnitLocation}");
        writer.WriteLine();
    }
}

void WriteMaterialDetails(StreamWriter writer, MaterialsClass? materials)
{
    if (materials != null)
    {
        if (materials.Preset != null && !string.IsNullOrEmpty(materials.Preset.RefrigerantR?.QTY)) writer.WriteLine($"Materials - Refrigerant {materials.Preset.RefrigerantR?.QTY}{materials.Preset.RefrigerantR?.Unit}");
        if (materials.Other != null)
        {
            if (materials.Other.CO2?.Used == true)
            {
                writer.Write($"Materials - CO2");
                for (int i = 0; i < (80 - "Materials - CO2".Length); i++) writer.Write($" ");
                writer.WriteLine();
            }
            if (materials.Other.N2?.Used == true)
            {
                writer.Write($"Materials - N2");
                for (int i = 0; i < (80 - "Materials - N2".Length); i++) writer.Write($" ");
                writer.WriteLine();
            }
            for (int i = 3; i <= 15; i++)
            {
                var propertyName = "Item" + i;
                var item = (MaterialsItemClass?)typeof(OtherClass).GetProperty(propertyName)?.GetValue(materials.Other);
                if (!string.IsNullOrEmpty(item?.MaterialUsed)) WriteItemDetails(writer, item);
            }
        }
    }
}

void WriteItemDetails(StreamWriter writer, MaterialsItemClass? item)
{
    string temp = $"Materials - {item?.MaterialUsed} * {item?.QTY} {(item?.Whol == true ? "from wholesaler" : (item?.TS == true ? "from truck stock" : (item?.Shop == true ? "from shop" : "")))}";
    if (item != null && !string.IsNullOrEmpty(item.MaterialUsed) && !string.IsNullOrEmpty(item.QTY)) writer.Write(temp);
    for (int i = 0; i < (80 - temp.Length); i++) writer.Write($" ");
    if (item?.Price != null) writer.Write($"{item?.Price:F2}");
    writer.WriteLine();
}

Thread.Sleep(5000);