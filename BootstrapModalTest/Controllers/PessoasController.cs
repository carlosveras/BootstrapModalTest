using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using BootstrapModalTest.DataContexts;
using BootstrapModalTest.Models;

namespace BootstrapModalTest.Controllers
{
    public class PessoasController : Controller
    {
        private ProgramDb db = new ProgramDb();

        // GET: Pessoas
        public async Task<ActionResult> Index()
        {
            return View(await db.Pessoas.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = await db.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,SobreNome,Email")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return PartialView("_Create", pessoa);
        }


        // GET: People/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = await db.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", pessoa);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,SobreNome,Email")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView("_Edit", pessoa);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = await db.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", pessoa);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pessoa pessoa = await db.Pessoas.FindAsync(id);
            db.Pessoas.Remove(pessoa);
            await db.SaveChangesAsync();
            return Json(new { success = true });
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
