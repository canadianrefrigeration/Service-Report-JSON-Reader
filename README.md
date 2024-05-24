# Service Report Generator

This project is to build a single exe to create service report drafts.

## Main files

Program.cs is the main flow of the generator. The document flow is in "using (StreamWriterwriter=newStreamWriter(draftPath)){}"

## Before Test

Change the folder name from ProgramPublic.txt to Program.cs

Update the paths in Program.cs

## Test run

```
dotnet build
dotnet run
```

## Publish to Desktop

```
dotnet publish
```
