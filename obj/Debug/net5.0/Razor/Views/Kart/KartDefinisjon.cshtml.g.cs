#pragma checksum "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90310ed5af0302754832d907242038d7b5c7b615"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kart_KartDefinisjon), @"mvc.1.0.view", @"/Views/Kart/KartDefinisjon.cshtml")]
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
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90310ed5af0302754832d907242038d7b5c7b615", @"/Views/Kart/KartDefinisjon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4a0d041100f1c7f5b87fd2c1f80209d75b00ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Kart_KartDefinisjon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KipWeb5.Models.Kart.KartModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Ny.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Lagre.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Slette.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_KartDefinisjonInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("controller", new global::Microsoft.AspNetCore.Html.HtmlString("Bestilling"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Lagre"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formKart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mt-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
  
    ViewData["Title"] = Localizer["Bestilling"];
    ViewData["LogOnOk"] = "2";
    ViewData["Menu"] = "GP";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<script type=\"text/x-kendo-tmpl\" id=\"template2\">\r\n    <div class=\"folder\">\r\n        <img src=\"");
#nullable restore
#line 16 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
             Write(Url.Content("~/images/#: icon#.svg"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n        <p>#:fileTittel#</p>\r\n    </div>\r\n</script>\r\n\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.2.2/pdf.js\"></script>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90310ed5af0302754832d907242038d7b5c7b6157937", async() => {
                WriteLiteral("\r\n    <div id=\"confirm\"></div>\r\n\r\n    <div class=\"container-fluid\">\r\n\r\n        <div class=\"row\" id=\"heading\" style=\"min-height: 70px;\">\r\n\r\n            <div class=\"col-2 unselectable\">\r\n                <h3>");
#nullable restore
#line 32 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
               Write(Localizer["Kart"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h3>
            </div>

            <div class=""col-10"">

                <div style=""display: flex; flex-direction: row;"">
                   
                   
                </div>

            </div>

        </div>

        <div class=""row"" style=""min-height: 720px; border: 1px solid lightgrey; padding: 10px;"">

            <div class=""col-4"">

                <div class=""row"">

                    <div class=""col-lg-7"" style=""display: flex; flex-direction: row;"">

                        <div>
                            <button type=""button"" name=""nyMappe"" class=""commandline"" onclick=""nyBestilling()"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "90310ed5af0302754832d907242038d7b5c7b6159345", async() => {
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
                WriteLiteral(@"
                                <figcaption>Ny</figcaption>
                            </button>
                        </div>

                        <div>
                            <button type=""button"" class=""commandline"" onclick=""lagreBestilling()"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "90310ed5af0302754832d907242038d7b5c7b61510733", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                <figcaption>Lagre</figcaption>
                            </button>
                        </div>

                        <div>
                            <button type=""button"" style=""display: none"" name=""mappeEndre"" id=""mappeEndre"" class=""commandline"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "90310ed5af0302754832d907242038d7b5c7b61512157", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                Slette
                            </button>
                        </div>

                    </div>

                   
                </div>

                <div class=""row"" style=""margin-top: 20px;"" >
                    <div class=""col-12"">
                    <div class=""row"">
                        <div class=""d-flex"">
                            <h4 class=""me-auto align-self-end unselectable"">");
#nullable restore
#line 84 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
                                                                       Write(Localizer["Liste over Kart"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h4>
                                                        
                        </div>
                    </div>
                    
                    <div class=""row"">
                        <div class=""col-12"">
                        ");
#nullable restore
#line 91 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
                    Write(Html.Kendo().Grid<KipWeb5.Models.KartItem>()
                            .Name("kartListe")
                            .Columns(columns =>
                            {
                                columns.Bound(q => q.KartGuid).Visible(false);
                                columns.Bound(q => q.Navn);
                            })
                            .HtmlAttributes(new {style = "height: calc(100vh - 370px);"})
                            .Scrollable()
                            .Selectable(s => s
                                .Mode(GridSelectionMode.Single)
                                .Type(GridSelectionType.Row))
                            .Events(events => events
                                .Change("onBestillingChange"))
                            .DataSource(dataSource => dataSource
                                .Ajax()
                                .Read(read => read.Action("getKartListe", "Kart"))
                                )
                            );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                 \r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n\r\n            <div class=\"col-8\" style=\"margin-top: 136px;\">\r\n\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "90310ed5af0302754832d907242038d7b5c7b61515754", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<script id=\"successTemplate\" type=\"text/x-kendo-template\">\r\n    <div class=\"upload-success\">\r\n        <img src=\"");
#nullable restore
#line 132 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
             Write(Url.Content("~/images/emoticon-happy.svg"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"float:left; height:48px; width:48px; margin-right: 16px;\"/>\r\n        <p>#= message #</p>\r\n    </div>\r\n</script>\r\n\r\n\r\n<script id=\"errorTemplate\" type=\"text/x-kendo-template\">\r\n    <div class=\"wrong-pass\">\r\n        <img src=\"");
#nullable restore
#line 140 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
             Write(Url.Content("~/images/emoticon-sad.svg"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"float:left; height:48px; width:48px; margin-right: 16px;\"/>\r\n        <p>#= message #</p>\r\n    </div>\r\n</script>\r\n\r\n\r\n");
#nullable restore
#line 146 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
Write(Html.Kendo().Notification()
    .Name("notification")
    .Position(p => p.Pinned(true).Top(30).Right(30))
    .Stacking(NotificationStackingSettings.Down)
    .AutoHideAfter(5000)
    .Templates(t =>
    {
        t.Add().Type("success").ClientTemplateID("successTemplate");
        t.Add().Type("error").ClientTemplateID("errorTemplate");
    })
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n    ");
#nullable restore
#line 159 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
Write(Html.Kendo().Window()
        .Name("DialogHjelp")
        .Title(Localizer["Hjelp"].Value)
        .Visible(false)
        .Height(800)
        .Width(1200)
        .Modal(true)
        .Draggable()
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<script id=\"hjelp\">\r\n\r\n    function showHelp() {\r\n       $.ajax({\r\n            url: \'");
#nullable restore
#line 173 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
             Write(Url.Action("DialogHjelp", "Hjelp"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: 'GET'
            }).done(function (result) {
                $('#DialogHjelp').html(result);
                var popup = $('#DialogHjelp').data(""kendoWindow"");
                popup.center().open();
            });
        }

    function hjelpFilter() {
        return {Modul: 12, Skjerm: ""Bestilling""}
        }

</script>


<script>

    $(window).on(""resize"", function(){
        $(""#kartListe"").data(""kendoGrid"").refresh();
        });


   
</script>

<script id=""dialogbokser"">
    var kalender = ""Seremoni"";

</script>

<script id=""submit"">

    function lagreBestilling() {

        var $this = $('#formKart');

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 212 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
             Write(Url.Action("LagreKart", "Kart"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: $this.serialize(),
            dataType: 'json'
            })
        .done(function (result) {
            if (result.Result == true) {
                var notification = $(""#notification"").data(""kendoNotification"");
                notification.show({title: ""Bestilling"", message: ""Bestillingen er lagret""}, ""success"");

                var grdBestillinger = $(""#kartListe"").data(""kendoGrid"");
                grdBestillinger.dataSource.read();
                }
            })
        .fail(function (result) {
            alert(result.ErrorText);
            });
     }

</script>


<script id=""funksjoner"">
    var Kontakt = """";

    $(document).bind('keydown', function(e) {
        if(e.ctrlKey && (e.which == 83)) {
            e.preventDefault();
            lagreBestilling();
            }
    });

   
</script>

<script id=""events"">
    var refresh = true;

    function onBestillingChange(e) {
            var selected = this.select();
            v");
            WriteLiteral("ar data = this.dataItem(selected);\r\n\r\n        var KartGuid = data.KartGuid;\r\n            $.ajax({\r\n                url: \'");
#nullable restore
#line 255 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
                 Write(Url.Action("GetKart", "Kart"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
                data: { KartGuid: KartGuid },
                type: ""GET""
            }).done(function (result) {
            $(""#kartForm"").html(result);
            });
        }


</script>



<script type=""text/javascript"">

 
    function nyBestilling() {
        $.ajax({
            url: '");
#nullable restore
#line 273 "C:\Visual Stuido 17\KipWeb5\Views\Kart\KartDefinisjon.cshtml"
             Write(Url.Action("NyBestilling", "Bestilling"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: ""GET""
        }).always(function (result) {
            $(""#bestillingForm"").html(result);
        });
    }

</script>

<script>

    $(document).bind('keydown', function(e) {
        if(e.ctrlKey && (e.which == 70)) {
            e.preventDefault();
            finnBestilling();
            }
        else if(e.ctrlKey && (e.which == 68)) {
            e.preventDefault();
            clearBestilling();
            }
        });


</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KipWeb5.Models.Kart.KartModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
