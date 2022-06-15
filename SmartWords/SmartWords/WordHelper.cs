using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;




namespace SmartWords
{

    class WordHelper

    {
        private FileInfo _fileInfo;

        public WordHelper(string fileName)

        {
            if(File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach(var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }
                Object newFileName = Path.Combine(_fileInfo.DirectoryName, _fileInfo.Name);
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.DefaultExt = ".doc";
                savefile.Filter = "Test files|*.docx";
                if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    app.ActiveDocument.SaveAs2(savefile.FileName);
                }
                app.ActiveDocument.Close();


                return true;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
           if (app != null)
                {
                    app.Quit();
                }
            }

            return false;
        }
    }
}

