using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using PR_1_GLUEFTUNG.Model;

namespace PR_1_GLUEFTUNG.DB_Model
{
    public class WriteLog
    {
        public void WriteLogEntry(Engine engData)
        {
            tblEngineLog1 _data = new tblEngineLog1()
            {
                ActCurrent = engData.Act_current.ToString("F2") + "[ma]",
                ActPower = engData.Act_power.ToString("F2") + "[W]",
                ActSpeed = engData.Act_speed.ToString("F2") + "[U/min]",
                ActVoltage = engData.Act_voltage.ToString("F2") + "[V]",
                ActDate = DateTime.Now.ToString()
            };

            using (LogGLueftungEntities context = new LogGLueftungEntities())
            {
                context.tblEngineLog1.Add(_data);
                context.SaveChanges();
            }
        }
    }
}
