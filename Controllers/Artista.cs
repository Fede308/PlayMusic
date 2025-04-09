namespace PlayMusic.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using PlayMusic.Models;
    public class ArtistaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Artista
        public ActionResult Index()
        {
            return View(db.Artistas.ToList());
        }
        // GET: Artista/Details/5
        public ActionResult Details(int id)
        {
            Artista artista = db.Artistas.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }
        // GET: Artista/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Artista/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Artistas.Add(artista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artista);
        }
        // GET: Artista/Edit/5
        public ActionResult Edit(int id)
        {
            Artista artista = db.Artistas.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }
        // POST: Artista/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Artista artista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artista);
        }
        // GET: Artista/Delete/5
        public ActionResult Delete(int id)
        {
            Artista artista = db.Artistas.Find(id);
            if (artista == null)
            {
                return HttpNotFound();
            }
            return View(artista);
        }
        // POST: Artista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artista artista = db.Artistas.Find(id);
            db.Artistas.Remove(artista);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Artista/Buscar
        public ActionResult Buscar(string nombre)
        {
            var artistas = db.Artistas.Where(a => a.Nombre.Contains(nombre)).ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorCancion
        public ActionResult BuscarPorCancion(string titulo)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Titulo.Contains(titulo)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorAlbum
        public ActionResult BuscarPorAlbum(string album)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Album.Contains(album)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorGenero
        public ActionResult BuscarPorGenero(string genero)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Genero.Contains(genero)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorDuracion

        public ActionResult BuscarPorDuracion(int duracion)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Duracion == duracion))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorUrl
        public ActionResult BuscarPorUrl(string url)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Url.Contains(url)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorArtista
        public ActionResult BuscarPorArtista(string nombre)
        {
            var artistas = db.Artistas
                .Where(a => a.Nombre.Contains(nombre))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorArtistaYAlbum
        public ActionResult BuscarPorArtistaYAlbum(string nombre, string album)
        {
            var artistas = db.Artistas
                .Where(a => a.Nombre.Contains(nombre) && a.Canciones.Any(c => c.Album.Contains(album)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorArtistaYGenero
        public ActionResult BuscarPorArtistaYGenero(string nombre, string genero)
        {
            var artistas = db.Artistas
                .Where(a => a.Nombre.Contains(nombre) && a.Canciones.Any(c => c.Genero.Contains(genero)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorArtistaYDuracion
        public ActionResult BuscarPorArtistaYDuracion(string nombre, int duracion)
        {
            var artistas = db.Artistas
                .Where(a => a.Nombre.Contains(nombre) && a.Canciones.Any(c => c.Duracion == duracion))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorArtistaYUrl
        public ActionResult BuscarPorArtistaYUrl(string nombre, string url)
        {
            var artistas = db.Artistas
                .Where(a => a.Nombre.Contains(nombre) && a.Canciones.Any(c => c.Url.Contains(url)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorAlbumYGenero
        public ActionResult BuscarPorAlbumYGenero(string album, string genero)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Album.Contains(album) && c.Genero.Contains(genero)))
                .ToList();
            return View(artistas);
        }
        // GET: Artista/BuscarPorAlbumYDuracion
        public ActionResult BuscarPorAlbumYDuracion(string album, int duracion)
        {
            var artistas = db.Artistas
                .Where(a => a.Canciones.Any(c => c.Album.Contains(album) && c.Duracion == duracion))
                .ToList();
            return View(artistas);
        }
    }
}