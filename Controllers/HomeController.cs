using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programacion_Unidad_2.Models;
using Programacion_Unidad_2.Models.ViewModels;


namespace Programacion_Unidad_2.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			MapaCurricularContext context = new();
			var Indx = context.Carreras.OrderBy(x => x.Nombre);
			return View(Indx);
		}


		[Route("informacion/{Informacion}")]
		public IActionResult Informacion(string Informacion)
		{
			string nom = Informacion.Replace("-", " ");
			MapaCurricularContext context = new();
			var Inf = context.Carreras.FirstOrDefault(x => x.Nombre == Informacion || nom == x.Nombre);

			if (Inf == null)
			{
				RedirectToAction("Index");
			}
			return View(Inf);
		}
		[Route("Mapa/{Mapa}")]
		public IActionResult Mapa(string Mapa)
		{
			string nombreCarrera = Mapa.Replace("-", " ");
			MapaCurricularContext context = new();
			var carrera = context.Carreras
				.Include(x => x.Materias)
				.FirstOrDefault(c => c.Nombre == Mapa || c.Nombre == nombreCarrera);

			if (carrera == null)
			{
				return RedirectToAction("Index");
			}

			var viewModel = new CarreraViewModel
			{
				Carrera = carrera.Nombre,
				Programa = carrera.Plan,
				CreditosTotales = carrera.Materias.Sum(x => x.Creditos),
				Semestres = Enumerable.Range(1, 9).Select(i => new SemestreView
				{
					NumSemestre = i,
					Materias = carrera.Materias
						.Where(m => m.Semestre == i)
						.Select(m => new MateriaView
						{
							Codigo = m.Clave,
							Titulo = m.Nombre,
							Creditos = m.Creditos,
							Practica = m.HorasPracticas,
							Teoria = m.HorasTeoricas
						})
						.ToList()
				}).ToList()
			};

			return View(viewModel);
		}
	}
	}
