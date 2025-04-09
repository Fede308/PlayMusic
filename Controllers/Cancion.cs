namespace PlayMusic.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using PlayMusic.Models;
    public class CancionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cancion
        public ActionResult Index()
        {
            var canciones = db.Canciones.Include(c => c.Artista);
            return View(canciones.ToList());
        }
        // GET: Cancion/Details/5
        public ActionResult Details(int id)
        {
            Cancion cancion = db.Canciones.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }
        // GET: Cancion/Create
        public ActionResult Create()
        {
            ViewBag.fkArtista = new SelectList(db.Artistas, "Id", "Nombre");
            return View();
        }
        // POST: Cancion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,fkArtista,Album,Genero,Duracion,Url")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Canciones.Add(cancion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkArtista = new SelectList(db.Artistas, "Id", "Nombre", cancion.fkArtista);
            return View(cancion);
        }
        // GET: Cancion/Edit/5
        public ActionResult Edit(int id)
        {
            Cancion cancion = db.Canciones.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkArtista = new SelectList(db.Artistas, "Id", "Nombre", cancion.fkArtista);
            return View(cancion);
        }
        // POST: Cancion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,fkArtista,Album,Genero,Duracion,Url")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkArtista = new SelectList(db.Artistas, "Id", "Nombre", cancion.fkArtista);
            return View(cancion);
        }
        // GET: Cancion/Delete/5
        public ActionResult Delete(int id)
        {
            Cancion cancion = db.Canciones.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }
        // POST: Cancion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancion cancion = db.Canciones.Find(id);
            db.Canciones.Remove(cancion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Cancion/Buscar
        public ActionResult Buscar(string searchString)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                canciones = canciones.Where(c => c.Titulo.Contains(searchString));
            }
            return View(canciones.ToList());
        }
        // GET: Cancion/Filtrar
        public ActionResult Filtrar(string searchString)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                canciones = canciones.Where(c => c.Genero.Contains(searchString));
            }
            return View(canciones.ToList());
        }
        // GET: Cancion/FiltrarArtista
        public ActionResult FiltrarArtista(string searchString)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                canciones = canciones.Where(c => c.Artista.Nombre.Contains(searchString));
            }
            return View(canciones.ToList());
        }
        // GET: Cancion/FiltrarAlbum
        public ActionResult FiltrarAlbum(string searchString)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                canciones = canciones.Where(c => c.Album.Contains(searchString));
            }
            return View(canciones.ToList());
        }
        // GET: Cancion/FiltrarDuracion
        public ActionResult FiltrarDuracion(int? duracion)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (duracion.HasValue)
            {
                canciones = canciones.Where(c => c.Duracion == duracion);
            }
            return View(canciones.ToList());
        }
        // GET: Cancion/FiltrarUrl
        public ActionResult FiltrarUrl(string searchString)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                canciones = canciones.Where(c => c.Url.Contains(searchString));
            }
            return View(canciones.ToList());
        }
        // GET: Cancion/FiltrarGenero
        public ActionResult FiltrarGenero(string searchString)
        {
            var canciones = from c in db.Canciones
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                canciones = canciones.Where(c => c.Genero.Contains(searchString));
            }
            return View(canciones.ToList());
        }
    }
}
