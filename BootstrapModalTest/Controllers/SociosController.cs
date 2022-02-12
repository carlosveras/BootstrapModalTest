using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BootstrapModalTest.DataContexts;
using BootstrapModalTest.Models;

namespace BootstrapModalTest.Controllers
{
    public class SociosController : Controller
    {
        private ProgramDb db = new ProgramDb();

        // GET: Socios
        public async Task<ActionResult> Index()
        {
            return View(await db.Socios.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = await db.Socios.FindAsync(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", socio);
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Socios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SocioID,Nome,SobreNome,NrSocio,DataInclusao,DataPrimHosp,AtivoInativo,Apelido,Sexo,Tratamento")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                db.Socios.Add(socio);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return PartialView("_Create", socio);
        }

        // GET: Socios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = await db.Socios.FindAsync(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SocioID,Nome,SobreNome,NrSocio,DataInclusao,DataPrimHosp,AtivoInativo,Apelido,Sexo,Tratamento")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = await db.Socios.FindAsync(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", socio);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Socio socio = await db.Socios.FindAsync(id);
            db.Socios.Remove(socio);
            await db.SaveChangesAsync();
            return Json(new { success = true });
        }

        /// <summary>
        /// <param name="Apelido"></param>
        /// <returns></returns>
        public JsonResult ckApelido(string Apelido)
        {
            return Json(!db.Socios.Any(lo => lo.Apelido == Apelido), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ckEntreDatas(DateTime DataPrimHosp, DateTime DataInclusao)
        {
            int qtosDias = Convert.ToInt16((DataPrimHosp - DataInclusao).TotalDays);
            return Json(qtosDias >= 0, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
