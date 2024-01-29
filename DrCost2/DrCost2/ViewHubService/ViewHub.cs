using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrCost2.dtoservices;

namespace DrCost2.ViewHubService
{
    public class ViewHub
    {
        Dictionary<string, Type> _participantTypes = new Dictionary<string, Type>();
        Dictionary<string, IViewBusParticipant> _partInstances = new Dictionary<string, IViewBusParticipant>();

        public ViewHub()
        {
        }

        //public IViewBusParticipant getParticipant(string name)
        //{
        //    if (_partInstances.TryGetValue(name, out IViewBusParticipant? participant))
        //    {
        //        return participant;
        //    }
        //    else
        //    {
        //        Console.WriteLine("No type found with the key 'nameA'.");
        //        return null;
        //    }
        //}

        public void Publish(ViewBusMessage msg)
        {
            if (_partInstances.TryGetValue(msg.To, out IViewBusParticipant? participant))
            {
                participant.PutMessage(msg);
            }
            else
            {
                throw new InvalidOperationException($"Target participant {msg.To} could not be find");
            }
        }

        /// <summary>
        /// Регистрация экземпляра. Присвоение имени проходит вручную.
        /// </summary>
        /// <param name="partc"></param>
        /// <param name="partcName"></param>
        public void RegisterManually(IViewBusParticipant partc, string partcName)
        {
			//         var viewPartType = partc.GetType();

			//var attribute = viewPartType.GetCustomAttribute<BusViewParticAttribute>();
			//if (attribute != null)
			//{
			//	_participantTypes.Add(attribute.name, viewPartType);
			//	_partInstances.Add(attribute.name, partc);
			//}

			_partInstances.Add(partcName, partc);
		}

        // поиск модулей и тут же создание коллекции экземпляров
        public void scanForViewParticipants()
        {
            _participantTypes = new Dictionary<string, Type>();

            // Get the executing assembly. If you want to scan a different assembly, replace with appropriate method.
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (var viewParticipantType in assembly.GetTypes())
            {
                var attribute = viewParticipantType.GetCustomAttribute<BusViewParticAttribute>();
                if (attribute != null)
                {
                    _participantTypes.Add(attribute.name, viewParticipantType);

                    var viewParticipantInstance = Activator.CreateInstance(viewParticipantType, new[] { this });

                    if (viewParticipantInstance is IViewBusParticipant)
                        _partInstances.Add(attribute.name, viewParticipantInstance as IViewBusParticipant);
                }
            }
        }
    }
}
