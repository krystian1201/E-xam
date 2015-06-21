
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamDomain.Model;
using Shared.Repository;

namespace E_xam.MVCWebUI.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IRepository<Exam> _repository;

        public ExamsController()
        {
            _repository = new Repository<Exam>(new ApplicationDbContext());
        }

        // GET: Exams
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var exams = _repository.GetAll().ToList();

            IEnumerable<ExamViewModel> examViewModels = exams.Select(exam => new ExamViewModel(exam)).ToList();
           
            return View(examViewModels);
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Exam exam = _repository.GetById(id.Value);
            if (exam == null)
            {
                return HttpNotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date,Duration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(exam);

                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Exam exam = _repository.GetById(id.Value);
            if (exam == null)
            {
                return HttpNotFound();
            }

            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date,Duration")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(exam);

                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exams/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Exam exam = _repository.GetById(id.Value);
            if (exam == null)
            {
                return HttpNotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
