namespace ex1evaJGG
{
    public class Notes
    {
        private Dictionary<string, double> _SubjectNotes = new Dictionary<string, double>();
        
        public Notes()
        {
            _SubjectNotes.Add("Mathematics", 0);
            _SubjectNotes.Add("Science", 0);
            _SubjectNotes.Add("History", 0);
            _SubjectNotes.Add("Spanish", 0);
        }

        public void AddSubject(string subject)
        {
            foreach (var key in _SubjectNotes.Keys)
            {
                if (key == subject)
                    return;
            }
            _SubjectNotes.Add(subject, 0);
        }

        public List<double> GetNotes()
        {
            List<double> notes = new List<double>();
            foreach (var note in _SubjectNotes.Values)
            {
                notes.Add(note);
            }
            return notes;
        }

        //public List<string> GetSubjects()
        //{
        //    List<string> subjects = new List<string>();
        //    foreach (var subject in _SubjectNotes.Keys)
        //    {
        //        subjects.Add(subject);
        //    }
        //    return subjects;
        //}

        public double GetQualificationForSubject(string subject)
        {
            return (_SubjectNotes == null || !_SubjectNotes.ContainsKey(subject)) ? double.MinValue : _SubjectNotes[subject];
        }

        public void SetQualificationForSubject(string subject, double note)
        {
            if (_SubjectNotes == null || !_SubjectNotes.ContainsKey(subject))
                return;
            _SubjectNotes[subject] = note;
        }
       
        public double GetAverageNote()
        {
            if (_SubjectNotes == null || _SubjectNotes.Count <= 0)
                return double.MinValue;

            double averageNote = 0;

            foreach(var note in _SubjectNotes.Values)
            {
                averageNote += note;
            }
            averageNote /= _SubjectNotes.Count;
            return averageNote;
        }

        public double GetMaxNote()
        {
            List<double> notes = GetNotes();
            double maxNote = notes[0];
            foreach (var note in notes)
            {
                if (note > maxNote)
                    maxNote = note;
            }
            return maxNote;
        }

        public double GetMinNote()
        {
            List<double> notes = GetNotes();
            double minNote = notes[0];
            foreach (var note in notes)
            {
                if (note < minNote)
                    minNote = note;
            }
            return minNote;
        }

        public string GetMaxNoteSubject()
        {
            double maxNote = GetMaxNote();
            foreach (var note in _SubjectNotes)
            {
                if (note.Value == maxNote)
                    return note.Key;
            }
            return string.Empty;
        }

        public string GetMinNoteSubject()
        {
            double minNote = GetMinNote();
            foreach (var note in _SubjectNotes)
            {
                if (note.Value == minNote)
                    return note.Key;
            }
            return string.Empty;
        }
    }
}
