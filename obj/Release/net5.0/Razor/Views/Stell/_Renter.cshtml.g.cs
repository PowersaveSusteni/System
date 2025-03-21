#pragma checksum "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54d996f44feb4d964616a6332ad3a2e7d72676f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stell__Renter), @"mvc.1.0.view", @"/Views/Stell/_Renter.cshtml")]
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
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54d996f44feb4d964616a6332ad3a2e7d72676f5", @"/Views/Stell/_Renter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4a0d041100f1c7f5b87fd2c1f80209d75b00ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Stell__Renter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KipWeb5.Models.Stell.StellModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/execute.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 0px solid #dddddd;
  text-align: left;
  padding: 4px;
}

</style>

<div class=""row"">
    <div class=""col-3"">
        <button type=""button"" class=""command"" style=""width: 250px; margin-right: 7px;"" onclick=""StartRentefordeling()"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "54d996f44feb4d964616a6332ad3a2e7d72676f54012", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
#nullable restore
#line 25 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
       Write(Localizer["Start fordeling renter"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <p>Arkiver epost</p>
        </button>
    </div>
    <div class=""col-4"">
        <div id=""tips"">
            <p class=""unselectable"">
                Velg bankkonto i listen og legg inn rentebeløpet. Trykk på <strong>Start fordeling renter</strong> for å fordele rentene på fondene
            </p>
        </div>
    </div>

    <div class=""col-4"">
        <div id=""progress"" class=""col-lg-12"" style=""margin-bottom: 10px; display: none"">
            <h4>Fremdrift</h4>
            <div class=""row align-items-center"" style=""display: flex; flex-direction: row; margin-bottom: 10px;"">
                <label class=""col-3"" for=""ProgressAntall"">Antall stellavtaler</label>
                <div class=col-6>
                    <input id=""ProgressAntall"" class=""form-control k-textbox"" style=""width: 120px;"" />
                </div>
            </div>
            ");
#nullable restore
#line 46 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
        Write(Html.Kendo().ProgressBar()
                .Name("Fremdrift")
                .HtmlAttributes(new { style = "width: 100%;" })
                .Type(ProgressBarType.Percent)
                .Animation(a => a.Duration(600))
                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-5\">\r\n         ");
#nullable restore
#line 58 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
     Write(Html.Kendo().Grid<KipWeb5.Models.BankItem>()
            .Name("Bank")
            .Columns(columns =>
            {
                columns.Bound(q => q.BankId).Width(40).Title(Localizer["#"].Value);
                columns.Bound(q => q.KontoNr).Width(160).Title(Localizer["Type"].Value);
                columns.Bound(q => q.Navn).Title(Localizer["Navn"].Value);
            })
            .Height(200)
            .Scrollable()
            .Selectable(s => s
                .Mode(GridSelectionMode.Single)
                .Type(GridSelectionType.Row))
            .Events(events => events
                .Change("onBankChange"))
            .DataSource(dataSource => dataSource
                .Ajax()
                .Read(read => read.Action("GetBankListe", "Stell"))
                )
            );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-6\">\r\n        <table style=\"border: 1px black\">\r\n            <tr>\r\n                <td>\r\n                    Rentebeløp\r\n                </td>\r\n                <td></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 87 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
                Write(Html.Kendo().NumericTextBox<float>()
                        .Name("Rentebelop")
                        .Format("n0")
                        .Min(0)
                        .HtmlAttributes(new { style = "width: 130px;" })
                        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    Gjelder for periode\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 100 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
                Write(Html.Kendo().DatePicker().Name("FraDato").HtmlAttributes(new { style = "width: 120px"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>");
#nullable restore
#line 102 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
                Write(Html.Kendo().DatePicker().Name("TilDato").HtmlAttributes(new { style = "width: 120px"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r\n                    Rentedato\r\n                </td>\r\n                <td></td>\r\n                <td>");
#nullable restore
#line 109 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
                Write(Html.Kendo().DatePicker().Name("RenteDato").HtmlAttributes(new { style = "width: 120px"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>Tjeneste</td>\r\n                <td colspan=2>\r\n                    ");
#nullable restore
#line 114 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
                Write(Html.Kendo().DropDownList()
                        .Name("Tjeneste")
                        .DataTextField("Tekst")
                        .DataValueField("TjenesteNr")
                        .DataSource(source => source
                            .Ajax()
                            .Read(read => read.Action("GetTjenesteListe", "Faktura").Data("filterTG"))
                        )                                            
                        .HtmlAttributes(new { style="width: 100%;" })
                    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>Minste saldo for fordeling</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 129 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
                Write(Html.Kendo().NumericTextBox<float>()
                        .Name("MinsteSaldo")
                        .Format("n0")
                        .Min(0)
                        .HtmlAttributes(new { style = "width: 130px;" })
                        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\" style=\"margin-top: 10px;\">\r\n\r\n    <div class=\"col-12\">\r\n\r\n    ");
#nullable restore
#line 145 "C:\Visual Stuido 17\KipWeb5\Views\Stell\_Renter.cshtml"
Write(Html.Kendo().Grid<KipWeb5.Models.StellAvtaleItem>()
        .Name("StellListe")
        .Columns(columns =>
        {
            columns.Bound(q => q.StellavtaleGuid).Visible(false);
            columns.Bound(q => q.StellAvtaleNr).Width(100).Title(Localizer["#"].Value);
            columns.Bound(q => q.StellNavn).Title(Localizer["Navn"].Value);
            columns.Bound(q => q.StartDato).Width(100).Format("{0: dd.MM.yyyy}").Title(Localizer["Opprettet"].Value);
            columns.Bound(q => q.Saldo).Width(200).Title(Localizer["Saldo"].Value).HtmlAttributes(new { style = "text-align: right;" });
        })
        .Height(360)
        .Scrollable()
        .Selectable(s => s
            .Mode(GridSelectionMode.Single)
            .Type(GridSelectionType.Row))
        .DataSource(dataSource => dataSource
            .Ajax()
            .PageSize(14)
            .Read(read => read.Action("GetRenteListe", "Stell").Data("filterBank"))
            )
        );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    </div>
</div>

<script>


    $(document).ready(function () {
            var today = new Date();
            var year = new Date().getFullYear()-1;
            //var year = today.toLocaleDateString('de-DE', { year: ""numeric"", month: ""2-digit"", day: ""2-digit"" });
            datoFra = ""01.01."" + year;
            datoTil = ""31.12."" + year;
            var xFraDato = $(""#FraDato"").data(""kendoDatePicker"");
            var xTilDato = $(""#TilDato"").data(""kendoDatePicker"");
            var xRenteDato = $(""#RenteDato"").data(""kendoDatePicker"");
            var xMinBelop = $(""#MinsteSaldo"").data(""kendoNumericTextBox"");
            xFraDato.value(datoFra);
            xTilDato.value(datoTil);
            xRenteDato.value(datoTil);
            xMinBelop.value(10);
        });



</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KipWeb5.Models.Stell.StellModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
