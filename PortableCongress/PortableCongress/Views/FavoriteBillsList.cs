#pragma warning disable 1591
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace PortableCongress.Views
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class FavoriteBillsList : PortableRazor.ViewBase
{

#line hidden

#line 2 "FavoriteBillsList.cshtml"
public System.Collections.Generic.List<Bill> Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<!DOCTYPE html>\n<html>\n<head>\n\t<meta");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral("/>\n\t<meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1\"");

WriteLiteral("/>\n\t<link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" href=\"jquery.mobile-1.4.5.min.css\"");

WriteLiteral(" />\n\t<script");

WriteLiteral(" src=\"jquery-1.11.1.min.js\"");

WriteLiteral("></script>\n\t<script");

WriteLiteral(" src=\"jquery.mobile-1.4.5.min.js\"");

WriteLiteral("></script>\n</head>\n<body>\n\t<div");

WriteLiteral(" data-role=\"header\"");

WriteLiteral(" style=\"overflow:hidden;\"");

WriteLiteral(" data-position=\"fixed\"");

WriteLiteral(">\n    \t<h1>Favorite Bills</h1>\n    </div>\n\n\t<ul");

WriteLiteral(" data-role=\"listview\"");

WriteLiteral(" data-inset=\"true\"");

WriteLiteral(">\n");


#line 18 "FavoriteBillsList.cshtml"
		

#line default
#line hidden

#line 18 "FavoriteBillsList.cshtml"
   foreach(var bill in Model) {


#line default
#line hidden
WriteLiteral("\t\t\t<li>\n\t    \t\t<a");

WriteAttribute ("href", " href=\"", "\""

#line 20 "FavoriteBillsList.cshtml"
, Tuple.Create<string,object,bool> ("", Url.Action("ShowFavoriteBillView", new {id = bill.Id })

#line default
#line hidden
, false)
);
WriteLiteral(">");


#line 20 "FavoriteBillsList.cshtml"
                                                                     Write(bill.Title);


#line default
#line hidden
WriteLiteral("</a>\n\t\t    </li>\n");


#line 22 "FavoriteBillsList.cshtml"
	    }


#line default
#line hidden
WriteLiteral("\t</ul>\n\t<div");

WriteLiteral(" data-role=\"footer\"");

WriteLiteral(" data-id=\"foo1\"");

WriteLiteral(" data-position=\"fixed\"");

WriteLiteral(">\n\t\t<div");

WriteLiteral(" data-role=\"navbar\"");

WriteLiteral(">\n\t\t\t<ul>\n\t\t\t\t<li><a");

WriteAttribute ("href", " href=\"", "\""

#line 27 "FavoriteBillsList.cshtml"
, Tuple.Create<string,object,bool> ("", Url.Action("ShowPoliticianList")

#line default
#line hidden
, false)
);
WriteLiteral(">Politicians</a></li>\n\t\t\t\t<li><a");

WriteAttribute ("href", " href=\"", "\""

#line 28 "FavoriteBillsList.cshtml"
, Tuple.Create<string,object,bool> ("", Url.Action("ShowFavoriteBills")

#line default
#line hidden
, false)
);
WriteLiteral(">Bills</a></li>\n\t\t\t</ul>\n\t\t</div>\n\t</div>\n</body>\n</html>");

}
}
}
#pragma warning restore 1591
