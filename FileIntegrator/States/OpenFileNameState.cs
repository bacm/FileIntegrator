using System;
using System.IO;
using System.Threading;
using FileIntegrator.Interfaces;

namespace FileIntegrator.States
{
    public class OpenFileNameState : IIntegrationState
    {
        private readonly IntegratedFile _file;

        public OpenFileNameState(IntegratedFile file)
        {
            _file = file;
        }

        public EIntegratorStep IntegratorStep
        {
            get { return EIntegratorStep.OpenFile; }
        }

        public void Execute()
        {
            WaitForUnlockedFile();
            TryToReadContent();
            OberthurFileIntegratorEventSource.Log.ContentHasBeenRead(_file.Filepath);
        }

        public IIntegrationState NextState()
        {
            return new AnalysisState(_file);
        }

        private void WaitForUnlockedFile()
        {
            var retries = 3;
            while (retries > 0)
            {
                if (IsFileLocked(new FileInfo(_file.Filepath)) == false)
                {
                    return;
                }

                Thread.Sleep(200);
                retries--;
            }

            throw new StateException(this, new Exception(string.Format("file {0} cannot be read", _file.Filepath)));
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void TryToReadContent()
        {
            try
            {
                _file.Contents = File.ReadAllLines(_file.Filepath);
            }
            catch (Exception ex)
            {
                throw new StateException(this, ex);
            }
        }
    }
}