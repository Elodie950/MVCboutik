using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBoutik.Helper
{
    public static class CustHelper
    {
        public static MvcHtmlString BoldTitle(this HtmlHelper Origin, string texte, string laclasse)
        {
            TagBuilder ta = new TagBuilder("h1");
            ta.InnerHtml = texte.ToUpper();
            ta.AddCssClass(laclasse);

            return new MvcHtmlString(ta.ToString());
        }
        public static MvcHtmlString MenuCategAndLang(this HtmlHelper origin, IEnumerable<Categories> categs)
        {
            /*Html a générer
             * <div class="panel-group category-products" id="accordian">
             * <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
                                        <span class="badge pull-right"><i class="fa fa-plus"></i></span>
                                        Junior Developer
                                    </a>
                                </h4>
                            </div>
                            <div id="sportswear" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <ul>
                                        <li><a href="#">.NET </a></li>
                                        <li><a href="#">PHP </a></li>
                                        <li><a href="#">HTML5 & CSS3 </a></li>
                                        <li><a href="#">ASP.NET</a></li>
                                        <li><a href="#">JQuery </a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        ...
                    </div>*/
            TagBuilder principal = new TagBuilder("div");
            principal.AddCssClass("category-products");
            principal.AddCssClass("panel-group");
            principal.Attributes.Add("id", "accordian");

            foreach (Categories CurrentCateg in categs)
            {
                //<div class="panel panel-default">
                TagBuilder DivCateg = new TagBuilder("div");
                DivCateg.AddCssClass("panel-default");
                DivCateg.AddCssClass("panel");

                //<div class="panel-heading">
                TagBuilder DivHeading = new TagBuilder("div");
                DivHeading.AddCssClass("panel-heading");
                // <h4 class="panel-title">
                TagBuilder H4 = new TagBuilder("h4");
                H4.AddCssClass("panel-title");
                //<a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
                TagBuilder atoggle = new TagBuilder("a");
                atoggle.Attributes.Add("data-parent", "#accordian");
                atoggle.Attributes.Add("data-toggle", "collapse");
                atoggle.Attributes.Add("href", "#" + CurrentCateg.CategLabel);
                //<span class="badge pull-right"><i class="fa fa-plus"></i></span>
                TagBuilder spanbadge = new TagBuilder("span");
                spanbadge.AddCssClass("pull-right");
                spanbadge.AddCssClass("badge");
                spanbadge.InnerHtml = "<i class=\"fa fa-plus\"></i>";

                atoggle.InnerHtml = spanbadge.ToString();
                atoggle.InnerHtml += CurrentCateg.CategLabel;
                H4.InnerHtml = atoggle.ToString();
                DivHeading.InnerHtml = H4.ToString();
                DivCateg.InnerHtml = DivHeading.ToString();


                //Ajout des langs
                // <div id="sportswear" class="panel-collapse collapse">
                TagBuilder tagLang = new TagBuilder("div");
                tagLang.Attributes.Add("id", CurrentCateg.CategLabel);
                tagLang.AddCssClass("collapse");
                tagLang.AddCssClass("panel-collapse");
                //<div class="panel-body">
                TagBuilder tagBody = new TagBuilder("div");
                tagBody.AddCssClass("panel-body");
                //ul
                TagBuilder tagUl = new TagBuilder("ul");
                foreach (ITLang item in CurrentCateg.ItLangs)
                {
                    TagBuilder tagLi = new TagBuilder("li");
                    tagLi.InnerHtml = "<a href=\"#\">" + item.ITLabel + "</a>";
                    //Ajout au ul
                    tagUl.InnerHtml += tagLi;

                }
                tagBody.InnerHtml = tagUl.ToString();
                tagLang.InnerHtml = tagBody.ToString();
                //Ajout categ
                DivCateg.InnerHtml += tagLang.ToString();
                //Ajout au principal
                principal.InnerHtml += DivCateg.ToString();

            }

            return new MvcHtmlString(principal.ToString());
        }

        public static MvcHtmlString ProgramingLanguage(this HtmlHelper origin, IEnumerable<ITLang> itLangs)
        {
            TagBuilder contenant = new TagBuilder("div");
            contenant.AddCssClass("brands-name");

            TagBuilder tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("nav-stacked");
            tagUl.AddCssClass("nav-pills");
            tagUl.AddCssClass("nav");
            foreach (ITLang lang in itLangs)
            {
                TagBuilder tagLi = new TagBuilder("li");
                TagBuilder tagA = new TagBuilder("a");
                tagA.Attributes.Add("href", "#");
                TagBuilder tagSpan = new TagBuilder("span");
                tagSpan.AddCssClass("pull-right");
                foreach (Developer item in lang.Developer)
                {
                    tagSpan.InnerHtml = "(" + lang.Developer.Count() + ")";
                }
                tagA.InnerHtml = tagSpan.ToString();
                tagA.InnerHtml += lang.ITLabel;
                tagLi.InnerHtml = tagA.ToString();
                tagUl.InnerHtml += tagLi;

            }

            contenant.InnerHtml = tagUl.ToString();
            return new MvcHtmlString(contenant.ToString());
        }

         /*<div class="col-sm-4">
                        <div class="product-image-wrapper">
                            <div class="single-products">
                                <div class="productinfo text-center">
                                    <img src="~/Content/images/home/product1.jpg" alt="" />
                                    <h2>Efje</h2>
                                    <p>Super Web Developer</p>
                                    <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                </div>
                                <div class="product-overlay">
                                    <div class="overlay-content">
                                        <h2>$56</h2>
                                        <p>Easy Polo Black Edition</p>
                                        <a href="#" class="btn btn-default add-to-cart"><i class="fa fa-shopping-cart"></i>Add to cart</a>
                                    </div>
                                </div>
                            </div>
                            <div class="choose">
                                <ul class="nav nav-pills nav-justified">
                                    <li><a href="#"><i class="fa fa-plus-square"></i>Add to wishlist</a></li>
                                    <li><a href="#"><i class="fa fa-plus-square"></i>Add to compare</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>*/
        public static MvcHtmlString AfficherDev(this HtmlHelper origin, IEnumerable<Developer> lesDev)
        {
            TagBuilder general = new TagBuilder("div");
            general.AddCssClass("col-sm-4");

            TagBuilder general2 = new TagBuilder("div");
            general2.AddCssClass("product-image-wrapper");

            TagBuilder moinGeneral = new TagBuilder("div");
            moinGeneral.AddCssClass("single-products");

            TagBuilder infoDev = new TagBuilder("div");
            infoDev.AddCssClass("text-center");
            infoDev.AddCssClass("productinfo");

           
            foreach(Developer dev in lesDev)
            { 
                TagBuilder imageDev = new TagBuilder("img");
                imageDev.Attributes.Add("src", "~/Content/images/home/"+ dev.DevPicture);
                
                TagBuilder h2 = new TagBuilder("h2");
                h2.InnerHtml = dev.DevHourCost.ToString() + "€/Hours";

                TagBuilder tagP = new TagBuilder("p");
                tagP.InnerHtml = ;
            
                TagBuilder tagA = new TagBuilder("a");
                tagA.Attributes.Add("href","#");
                tagA.AddCssClass("add-to-cart");
                tagA.AddCssClass("btn-default");
                tagA.AddCssClass("btn");

                TagBuilder tagI = new TagBuilder("i");
                tagI.AddCssClass("fa-shopping-cart"); 
                tagI.AddCssClass("fa"); 

                TagBuilder cache = new TagBuilder("div");
                cache.AddCssClass("product-overlay");

                TagBuilder sousCache = new TagBuilder("div");
                sousCache.AddCssClass("overlay-content");

                return
            } 

        }
        

    }
}