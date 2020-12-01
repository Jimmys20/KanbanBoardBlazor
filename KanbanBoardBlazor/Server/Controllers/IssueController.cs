using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssueController : ControllerBase
    {
        [HttpGet]
        public List<Issue> Get()
        {
            return issues;
        }

        private static readonly List<Issue> issues = new List<Issue>
        {
                new Issue
                {
                    id = 1,
                    stageKey = "Ongoing",
                    priority = Priority.CRITICAL,
                    title = "Elexus – Update",
                    assignees = "ΓΣ, ΧΚ, ΓΠ",
                    description = @"In – Out report στο Players Rating στο CRM
Other enhancements.
BI installation
Προσοχή – Ετοιμότητα για επίλυση τυχόν προβλήματος"

                },
                new Issue
                {
                    id = 2,
                    stageKey = "Ongoing",
                    priority = Priority.CRITICAL,
                    title = "Gibraltar – Upgrade",
                    description = @"StarSeries &Turnstile.
Προσοχή – StarTouch ..Net Framework, XMLs, StarCash new Movements window
@Ακης – Υπενθύμιση για :
«At the moment we applied a modification in your database
to Deny “Save” on movements for Members that are Barred/Suspended»
Πριν κάνουμε update πρέπει να το βρούμε και να μεταφερθεί ώστε να μην χαθεί η τρέχουσα λειτουργικότητα."

                },
                new Issue
                {
                    id = 3,
                    stageKey = "Ongoing",
                    priority = Priority.HIGH,
                    title = "Estoril - Government reporting (Slots & Tables)",
                    assignees = "ΑΡ, ΒΦ, ΧΠ",
                    description = @"Slots Reporting Requirements: Παραδόθηκαν  15 Νοεμβρίου – σε κατάσταση ελέγχου
Tables Reporting Requirements: Παράδοση 25-30 Νοεμβρίου"
                },
                new Issue
                {
                    id = 4,
                    stageKey = "Ongoing",
                    priority = Priority.HIGH,
                    title = "Φορολογικοί – MyDATA",
                    description = @"Παράταση μέχρι 01/01/20.
Μέχρι σήμερα η γραμμή είναι να εξακολουθούν να σημαίνοντα όλα τα παραστατικά με φορολογικό μηχανισμό (αλλά να στέλνονται στο MyData μόνο εισιτήρια εισόδου, ημερήσια αποτελέσματα τραπεζιών και ημερήσια αποτελέσματα slots).
Διερεύνηση αν για τα 3 παραστατικά που πρέπει να πάνε στο MyData μπορούμε να τα στείλουμε μέσω του φορολογικού. (ΒΚ με Α. Μποσδούκη)
Διερεύνηση αν μπορούμε να επιλέγουμε ποια παραστατικά θα στέλνονται από τον ΦΗΜ στο MyData και ποια όχι? (ΑΡ με Χ. Φιλιππίδη)"

                },
                new Issue
                {
                    id = 5,
                    stageKey = "Ongoing",
                    priority = Priority.HIGH,
                    title = "Boulogne Golden Palace – CRM & Promos Setup",
                    assignees = "ΓΣ, ΑΡ, ΧΠ"

                },
                new Issue
                {
                    id = 6,
                    stageKey = "Ongoing",
                    priority = Priority.HIGH,
                    title = "Regency – View Casino Link για MyData",
                    assignees = "ΑΡ"

                },
                new Issue
                {
                    id = 7,
                    stageKey = "Ongoing",
                    priority = Priority.HIGH,
                    title = "Finix – Include promo packages in Kiosk",
                    assignees = "ΑΡ"

                },
                new Issue
                {
                    id = 8,
                    stageKey = "Complete",
                    priority = Priority.LOW,
                    title = "P Svilengrad – AML",
                    assignees = "ΧΚ, ΓΣ"

                },
                new Issue
                {
                    id = 9,
                    stageKey = "Ongoing",
                    priority = Priority.MEDIUM,
                    title = "Maestral – Replace StarGear with StarAgent"

                },
                new Issue
                {
                    id = 10,
                    stageKey = "Pending",
                    priority = Priority.MEDIUM,
                    title = "Viva – Dates (Last Visit, κλπ)"

                },
                new Issue
                {
                    id = 11,
                    stageKey = "Ongoing",
                    priority = Priority.MEDIUM,
                    title = "Expenses Module"

                },
                new Issue
                {
                    id = 12,
                    stageKey = "Ongoing",
                    priority = Priority.MEDIUM,
                    title = "Bi"

                },
                new Issue
                {
                    id = 13,
                    stageKey = "Ongoing",
                    priority = Priority.MEDIUM,
                    title = "Εσωτερικές Εκπαιδεύσεις"

                },
                new Issue
                {
                    id = 14,
                    stageKey = "Pending",
                    priority = Priority.MEDIUM,
                    title = "Φλώρινα"

                },
                new Issue
                {
                    id = 15,
                    stageKey = "Pending",
                    priority = Priority.MEDIUM,
                    title = "ΛΟΥΤΡΑΚΙ – Εγκατάσταση Overview"

                },
                new Issue
                {
                    id = 16,
                    priority= Priority.MEDIUM,
                    stageKey = "Pending",
                    title = "Regency – Player Barrings interface with IGT Advantage"

                },
                new Issue
                {
                    id = 17,
                    priority = Priority.MEDIUM,
                    stageKey = "Pending",
                    title = "Rocks - Update Startouch"

                },
                new Issue
                {
                    id = 18,
                    stageKey = "Pending",
                    priority = Priority.MEDIUM,
                    title = "Estoril – Test of the Integration with government system API"

                }
            };
    }
}
