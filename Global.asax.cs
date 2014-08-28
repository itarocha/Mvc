/*
 * Created by SharpDevelop.
 * User: itamar.junior
 * Date: 25/02/2014
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc
{
	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
                name: "TheMatriz",
                url: "Matriz/{modalidadeId}/{etapaId}",
                defaults: new
                {
                    controller = "Home" 
                    ,action = "Matriz"
                    //,turnoId = UrlParameter.Optional
                    //,id = UrlParameter.Optional
                });

			routes.MapRoute(
                name: "MatrizSelecionar",
                url: "MatrizSelecionar",
                defaults: new
                {
                    controller = "Home" 
                    , action = "MatrizSelecionar"
                    //,turnoId = UrlParameter.Optional
                    //,id = UrlParameter.Optional
                });
            
			routes.MapRoute(
                name: "TheMatrizDisciplina",
                url: "MatrizDisciplina/{matrizId}/{disciplinaId}",
                defaults: new
                {
                    controller = "Home" 
                    ,action = "MatrizDisciplina"
                    //,turnoId = UrlParameter.Optional
                    ,disciplinaId = UrlParameter.Optional
                });

            /*
            routes.MapRoute(
                name: "AlunoNecessidadesEspeciaisEdit",
                url: "Alunos/NE/{id}/NId/{nId}",
                defaults: new
                {
                    controller = "Alunos",
                    action = "NecessidadesEspeciaisEdit",
                    nId = UrlParameter.Optional,
                }
            );
            */
                
			routes.MapRoute(
				"Default",
				"{controller}/{action}/{id}",
				new {
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				});
		}
		
		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
		}
	}
}
