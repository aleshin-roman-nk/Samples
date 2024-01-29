using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mvp_find_class
{
	public class Hub
	{
		Dictionary<string, Type> _participants = new Dictionary<string, Type>();
		Dictionary<string, IViewBusParticipant> _partInstances = new Dictionary<string, IViewBusParticipant>();

		public Hub() 
		{
			scanForParticipants();
		}

		public IViewBusParticipant getParticipant(string name)
		{
			if (_partInstances.TryGetValue(name, out IViewBusParticipant? participant))
			{
				return participant;
			}
			else
			{
				Console.WriteLine("No type found with the key 'nameA'.");
				return null;
			}
		}

		public void Publish(ViewBusMessage msg)
		{
            Console.WriteLine($"hub is dispatching a message from [{msg.From}]");

            if (_partInstances.TryGetValue(msg.To, out IViewBusParticipant? participant))
			{
				participant.PutMessage(msg);
			}
			else
			{
				Console.WriteLine("No type found with the key 'nameA'.");
			}
		}

		// поиск модулей и тут же создание коллекции экземпляров
		private void scanForParticipants()
		{
			_participants = new Dictionary<string, Type>();

			// Get the executing assembly. If you want to scan a different assembly, replace with appropriate method.
			Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("scanning for participants...");

            foreach (var viewParticipantType in assembly.GetTypes())
			{
				var attribute = viewParticipantType.GetCustomAttribute<ViewBusParticAttribute>();
				if (attribute != null)
				{
					_participants.Add(attribute.name, viewParticipantType);

                    Console.WriteLine($"participant found: {attribute.name}; class type name: {viewParticipantType.Name}");

                    var viewParticipantInstance = Activator.CreateInstance(viewParticipantType, new[] { this });

					if (viewParticipantInstance is IViewBusParticipant)
						_partInstances.Add(attribute.name, viewParticipantInstance as IViewBusParticipant);
				}
			}

            Console.WriteLine();
        }
	}
}
