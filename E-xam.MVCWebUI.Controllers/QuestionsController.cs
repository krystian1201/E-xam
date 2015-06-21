
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExamDomain.Model;
using Shared.Repository;

namespace E_xam.MVCWebUI.Controllers
{
    public class QuestionsController : Controller
    {
        
        private readonly IRepository<Question> _questionsRepository;
        private readonly IRepository<ClosedAnswer> _closedAnswersRepository; 

        public QuestionsController()
        {
            _questionsRepository = new Repository<Question>(new ApplicationDbContext());
            _closedAnswersRepository = new Repository<ClosedAnswer>(new ApplicationDbContext());
        }


        //GET: Questions/_ClosedQuestionPartial
        public ActionResult _ClosedQuestionPartial()
        {
             return PartialView();
        }


        //GET: Questions/_ClosedQuestionAnswersPartial
        public ActionResult _ClosedQuestionAnswersPartial(int numberOfAnswers)
        {
            ViewBag.numberOfAnswers = numberOfAnswers;

            return PartialView();
        }


        // GET: Questions
        public ActionResult Index()
        {
            
            return View(_questionsRepository.GetAll());
        }


        // GET: Questions/Details/5
        [Route("Question/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = _questionsRepository.GetById(id.Value);
            if (question == null)
            {
                return HttpNotFound();
            }

            if (question is ClosedQuestion)
            {
                ClosedQuestion closedQuestion = (ClosedQuestion) question;
                
                closedQuestion.AnswerChoices = _closedAnswersRepository.Find(a => a.ClosedQuestionID == closedQuestion.ID).ToList();

                return View("ClosedQuestionDetails", closedQuestion);
            }

            return View(question);
        }


        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TimeToRespond,Text,Points")] Question question)
        {
            if (ModelState.IsValid)
            {
                _questionsRepository.Add(question);

                return RedirectToAction("Index");
            }

            return View(question);
        }


        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = _questionsRepository.GetById(id.Value);

            if (question == null)
            {
                return HttpNotFound();
            }

            if (question is ClosedQuestion)
            {
                ClosedQuestion closedQuestion = (ClosedQuestion) question;
                closedQuestion.AnswerChoices = _closedAnswersRepository.Find(a => a.ClosedQuestionID == closedQuestion.ID).ToList();

                ViewBag.AnswerChoices = closedQuestion.AnswerChoices;
            }

            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TimeToRespond,Text,Points")] Question question)
        {
            if (ModelState.IsValid)
            {
                _questionsRepository.Update(question);

                //return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = _questionsRepository.GetById(id.Value);

            if (question == null)
            {
                return HttpNotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _questionsRepository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _questionsRepository.Dispose();
            base.Dispose(disposing);
        }

    }
}
