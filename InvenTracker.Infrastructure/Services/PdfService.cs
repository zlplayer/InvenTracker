using InvenTracker.Application.Dtos;
using InvenTracker.Application.Iterfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InvenTracker.Infrastructure.Services;

public class PdfService : IPdfService
{
    public byte[] GeneratePickupReport(IEnumerable<GetItemHistoryDto> history, string? userName, DateTime from, DateTime to)
    {
        var items = history.ToList();

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Element(c => ComposeHeader(c, userName));
                page.Content().Element(content => ComposeContent(content, items, from, to));

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("Strona ");
                    text.CurrentPageNumber();
                    text.Span(" z ");
                    text.TotalPages();
                });
            });
        });

        return document.GeneratePdf();
    }

    public byte[] GenerateWardrobePickupReport(IEnumerable<GetItemHistoryDto> history, string? wardrobeName, DateTime from, DateTime to)
    {
        var items = history.ToList();

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Element(c => ComposeWardrobeHeader(c, wardrobeName));
                page.Content().Element(content => ComposeWardrobeContent(content, items, from, to));
                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("Strona ");
                    text.CurrentPageNumber();
                    text.Span(" z ");
                    text.TotalPages();
                });
            });
        });

        return document.GeneratePdf();
    }

    private void ComposeWardrobeHeader(IContainer container, string? wardrobeName)
    {
        container.Column(col =>
        {
            col.Item().Text("Raport pobrań z szafy")
                .FontSize(18).Bold().AlignCenter();
            if (!string.IsNullOrEmpty(wardrobeName))
                col.Item().Text($"Szafa: {wardrobeName}")
                    .FontSize(11).AlignCenter().FontColor(Colors.Blue.Darken2);
            col.Item().Text($"Wygenerowano: {DateTime.Now:dd.MM.yyyy HH:mm}")
                .FontSize(9).AlignCenter().FontColor(Colors.Grey.Medium);
        });
    }

    private void ComposeWardrobeContent(IContainer container, List<GetItemHistoryDto> items, DateTime from, DateTime to)
    {
        container.Column(col =>
        {
            col.Spacing(8);

            col.Item().Text($"Zakres dat: {from:dd.MM.yyyy} – {to:dd.MM.yyyy}")
                .FontSize(9).Italic().FontColor(Colors.Grey.Darken2);

            col.Item().Text($"Liczba rekordów: {items.Count}").FontSize(9);

            col.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);   // Lp.
                    columns.RelativeColumn(2);    // Użytkownik
                    columns.RelativeColumn(2);    // Przedmiot
                    columns.RelativeColumn(1.5f); // Szuflada
                    columns.RelativeColumn(1.5f); // Przegroda
                    columns.ConstantColumn(45);   // Ilość
                    columns.RelativeColumn(1.5f); // Data
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCell).Text("Lp.");
                    header.Cell().Element(HeaderCell).Text("Użytkownik");
                    header.Cell().Element(HeaderCell).Text("Przedmiot");
                    header.Cell().Element(HeaderCell).Text("Szuflada");
                    header.Cell().Element(HeaderCell).Text("Przegroda");
                    header.Cell().Element(HeaderCell).AlignCenter().Text("Ilość");
                    header.Cell().Element(HeaderCell).Text("Data pobrania");
                });

                for (var i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    var rowStyle = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                    table.Cell().Element(c => DataCell(c, rowStyle)).Text($"{i + 1}");
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.UserName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.ItemName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.DrawerName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.PartitionName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).AlignCenter().Text(item.Quantity.ToString());
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.ActionAt.ToString("dd.MM.yyyy HH:mm"));
                }
            });
        });
    }

    private void ComposeHeader(IContainer container, string? userName)
    {
        container.Column(col =>
        {
            col.Item().Text("Raport pobrań")
                .FontSize(18).Bold().AlignCenter();
            if (!string.IsNullOrEmpty(userName))
                col.Item().Text($"Użytkownik: {userName}")
                    .FontSize(11).AlignCenter().FontColor(Colors.Blue.Darken2);
            col.Item().Text($"Wygenerowano: {DateTime.Now:dd.MM.yyyy HH:mm}")
                .FontSize(9).AlignCenter().FontColor(Colors.Grey.Medium);
        });
    }

    private void ComposeContent(IContainer container, List<GetItemHistoryDto> items, DateTime from, DateTime to)
    {
        container.Column(col =>
        {
            col.Spacing(8);

            col.Item().Text($"Zakres dat: {from:dd.MM.yyyy} – {to:dd.MM.yyyy}")
                .FontSize(9).Italic().FontColor(Colors.Grey.Darken2);

            col.Item().Text($"Liczba rekordów: {items.Count}").FontSize(9);

            col.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(30);   // Lp.
                    columns.RelativeColumn(2);    // Przedmiot
                    columns.RelativeColumn(2);    // Szafa
                    columns.RelativeColumn(1.5f); // Szuflada
                    columns.RelativeColumn(1.5f); // Przegroda
                    columns.ConstantColumn(45);   // Ilość
                    columns.RelativeColumn(1.5f); // Data
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCell).Text("Lp.");
                    header.Cell().Element(HeaderCell).Text("Przedmiot");
                    header.Cell().Element(HeaderCell).Text("Szafa");
                    header.Cell().Element(HeaderCell).Text("Szuflada");
                    header.Cell().Element(HeaderCell).Text("Przegroda");
                    header.Cell().Element(HeaderCell).AlignCenter().Text("Ilość");
                    header.Cell().Element(HeaderCell).Text("Data pobrania");
                });

                for (var i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    var rowStyle = i % 2 == 0 ? Colors.White : Colors.Grey.Lighten4;

                    table.Cell().Element(c => DataCell(c, rowStyle)).Text($"{i + 1}");
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.ItemName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.WardrobeName ?? "—");
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.DrawerName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.PartitionName);
                    table.Cell().Element(c => DataCell(c, rowStyle)).AlignCenter().Text(item.Quantity.ToString());
                    table.Cell().Element(c => DataCell(c, rowStyle)).Text(item.ActionAt.ToString("dd.MM.yyyy HH:mm"));
                }
            });
        });
    }

    private static IContainer HeaderCell(IContainer container) =>
        container
            .Background(Colors.Blue.Darken2)
            .Padding(5)
            .DefaultTextStyle(x => x.FontColor(Colors.White).Bold().FontSize(9));

    private static IContainer DataCell(IContainer container, string background) =>
        container
            .Background(background)
            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
            .Padding(4);
}