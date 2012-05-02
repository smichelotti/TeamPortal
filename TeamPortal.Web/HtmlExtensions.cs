using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Routing;

namespace TeamPortal.Web
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString NavLink(this HtmlHelper helper, string controller)
        {
            var currentController = helper.ViewContext.RouteData.Values["controller"].ToString();
            var teamId = helper.ViewContext.HttpContext.Session["TeamId"];
            var css = controller == currentController ? "active" : string.Empty;

            var tagBuilder = new TagBuilder("li");
            if (!string.IsNullOrEmpty(css))
            {
                tagBuilder.MergeAttribute("class", "active");
            }
            tagBuilder.InnerHtml = helper.ActionLink(controller, "Index", controller, new { teamId = teamId }, null).ToString();
            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return MvcHtmlString.Create(metadata.DisplayName ?? metadata.PropertyName);
        }

        public static MvcHtmlString BSLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return LabelFor(html, expression, new { @class = "control-label" });
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelFor(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}