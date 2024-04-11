# Service Report Generator

This project is to build a single exe to create service report drafts.

## Main files

Program.cs is the main flow of the generator. The document flow is in "using (StreamWriterwriter=newStreamWriter(draftPath)){}"

## Test run

```
dotnet build
dotnet run
```

## Publish to Desktop

```
dotnet publish --output "C:\Users\Owner\Desktop"
```
