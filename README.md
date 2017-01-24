This is example/test application which can used to test how to use HTML5 technology to create fast web sites.

Application very simple and does not contains lot of data but on "Contact" page there is one big picture which loading takes sometime if nothing is cached.


This project contains three different versions of test application which are:
# Standard MVC
Generated from Visual Studio MVC 5 template and set use worst possible configuration:
* Debug mode is enabled.
* Caching is totally disabled.


# Fast MVC
Copied from Standard MVC project and included these optimizations:
* Disabled debug mode from "Release" configuration.
 * This enables CSS ja JavaScript files [bundling and minification](https://www.asp.net/mvc/overview/performance/bundling-and-minification) to ASP.NET MVC.
 * It is important to have "Dynamic Content Compression" and "Static Content Compression" IIS roles installed to get full benefit from this one.
* Removing any "Cache-Control" and "Pragma" headers using Web.config configuration which allows ASP.NET MVC controlling these headers.
 * Disabled global caching using this code line on Home controllel: `[OutputCache(Duration = 0, VaryByParam = "none", Location = OutputCacheLocation.None, NoStore = true)]`
  * But enabled caching to "About" page because it does not contain any private inofrmation.
 * ASP.NET will now set "Cache-Control" header public for all bundled css/js -files so client do not need download them again on one year if they does not change during that time.
* Added <applicationInitialization> -section to Web.config which automatically loads mostly used parts to server memory when application pool starts.
 * Application pool start mode: AlwaysRunning, application preload=true setting and "Application Initialization" module are prerequirements for this one.
* Enabled PrecompileBeforePublish=True and EnableUpdateable=False to publish profile "FileSystem" which is used to build this project.
 * This increases little bit combiling time on build server but decreases application load times on server side.

 
# Super Fast HTML 5
Pure HTML 5 + JavaScript page which looks like same than earlier versions but works without any connections to server after it is cached to client side.

Purpose of this is prove that it is possible to create zero delay user interfaces using HTML 5 + JavaScript when needed.
Of course on real application some server connections are also needed but they should be handles on background always when possible.

* All three tabs "Home", "About" and "Contact" are bundled to index.html and CSS is used to hide non-active parts.
* Manifest file "superfasthtml5.appcache" is used to tell client that which files it needs to download locally.
 * This makes the trick that client will immediately start downloading big picture on "Contact" page and if user does not immediately jump there it will be downloaded already to cache.
