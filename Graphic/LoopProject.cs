using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;

namespace Graphic
{
    class LoopProject
    {
        private Game  game;

        public bool Running { get; private set; }

        public void Load(Game obj)
        {
            game = obj;
        }

        public async void Start()
        {
            if (game == null)
                throw new ArgumentException("Not load");

           
            game.Load();

            Running = true;

            DateTime _previousGameTime = DateTime.Now;

            while (Running)
            {
              
                TimeSpan GameTime = DateTime.Now - _previousGameTime;
                
                _previousGameTime = _previousGameTime + GameTime;
                
                game.Update(GameTime);
                
                
                await System.Threading.Tasks.Task.Delay(8);
            }
        }

        public void Stop()
        {
            Running = false;
            game?.Unload();
        }
      
        public void Draw()
        {
            game.Draw();
        }
    }
}
