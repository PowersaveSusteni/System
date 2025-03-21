#pragma checksum "C:\Visual Stuido 17\KipWeb5\Views\Rutiner\_AdresseHistorikk.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a8ab34f87d695d17ff59774c7bcb28306de82b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rutiner__AdresseHistorikk), @"mvc.1.0.view", @"/Views/Rutiner/_AdresseHistorikk.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\_ViewImports.cshtml"
using KipWeb5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Visual Stuido 17\KipWeb5\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\Rutiner\_AdresseHistorikk.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a8ab34f87d695d17ff59774c7bcb28306de82b7", @"/Views/Rutiner/_AdresseHistorikk.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4a0d041100f1c7f5b87fd2c1f80209d75b00ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Rutiner__AdresseHistorikk : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KipWeb5.Models.Kontakt.KontaktModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div id=\"kontaktFullForm\" class=\"container-fluid padding-0\">\r\n\r\n    <div class=\"row padding-0\" style=\"margin-top: 0px;\">\r\n\r\n        <div class=\"col-12\">\r\n\r\n            ");
#nullable restore
#line 13 "C:\Visual Stuido 17\KipWeb5\Views\Rutiner\_AdresseHistorikk.cshtml"
        Write(Html.Kendo().Grid<KipWeb5.Models.KontaktListeItem>()
                .Name("historikkGrid")
                .Columns(columns =>
                {
                    columns.Bound(q => q.Fra).ClientTemplate("<img src='" + Url.Content("~/images/Fra_") + "#:data.Fra#.png' width=24 height=24 alt='#: data.Fra#' />").Width(35).Title("Fra");
                    columns.Bound(q => q.PersonNr).Width(140).Title("Personnr");
                    columns.Bound(q => q.Født).Format("{0: dd.MM.yyyy}").Width(100).Title("Født");
                    columns.Bound(q => q.Fornavn).Width(150).Title("Fornavn");
                    columns.Bound(q => q.Mellomnavn).Title("Mellomnavn");
                    columns.Bound(q => q.Etternavn).Width(150).Title("Etternavn");
                    columns.Bound(q => q.Adresse).Width(170).Title("Adresse");
                    columns.Bound(q => q.PostNr).Width(70).Title("Postnr.");
                    columns.Bound(q => q.Sted).Width(170).Title("Sted");
                    columns.Bound(q => q.StatusDato).Format("{0: dd.MM.yyyy}").Width(100).Title("Status dato");
                    columns.Bound(q => q.KommuneNr).Visible(false).Width(100).Title("KommuneNr");
                    columns.Bound(q => q.KontaktGuid).Visible(false);
                    columns.Bound(q => q.ErDod).Visible(false);
                    columns.Bound(q => q.Type).Visible(false);
                })
                .Sortable()
                .Scrollable()
                .Height(450)
                .Selectable(s => s
                .Mode(GridSelectionMode.Single)
                .Type(GridSelectionType.Row))

                .DataSource(dataSource => dataSource
                    .Ajax()
                    .Read(read => read.Action("getKontaktListe", "Funksjoner").Data("filterSokHistorikk"))
                    )
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n<script>\r\n\r\n\r\n  \r\n\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KipWeb5.Models.Kontakt.KontaktModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
