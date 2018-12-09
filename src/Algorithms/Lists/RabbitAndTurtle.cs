using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Lists
{
// Следующий псевдокод демонстрирует алгоритм высокого уровня.
// 1. Запускаем «черепаху» из начала списка со скоростью одна ячейка за шаг
// и «кролика» со скоростью две ячейки за шаг.
// 2. Если «кролик» найдет ссылку null, список не содержит цикла.
// 3. Если «кролик» догонит «черепаху», перезапускаем его из начала списка со
// скоростью одна ячейка за шаг, в то время как «черепаха» продолжает дви-
// гаться с в прежнем темпе.
// 4. Когда «кролик» и «черепаха» снова встретятся, они будут находиться в на-
// чале цикла. Оставляем «кролика» в этом месте, чтобы он мог «отдохнуть»,
// пока «черепаха» движется по циклу.Момент, когда указатель Next «чере-
// пахи» покажет на ячейку, где ждет «кролик», и будет означать конец цикла.
// 5. Чтобы прервать цикл, устанавливаем указатель «черепахи» Next на null.
    public class RabbitAndTurtle
    {
        private readonly Item _root;
        private Item _turtle;
        private Item _rabbit;

        public RabbitAndTurtle(Item root)
        {
            _turtle = _rabbit = _root = root;
        }


        public Item FindCicleItem()
        {
            if (_rabbit == null || _turtle == null)
                return null;

            var rabbitPace = GetRabbitPace(RabbitPace.FirstRun);
            while (true)
            {
                // 1
                _rabbit = rabbitPace(_rabbit);
                _turtle = _turtle.Next;
                // 2
                if (_rabbit == null)
                    return null;
                // 3
                if (_rabbit == _turtle)
                    break;
            }

            // 3
            rabbitPace = GetRabbitPace(RabbitPace.SecondRun);
            _rabbit = _root;
            while (true)
            {
                _rabbit = rabbitPace(_rabbit);
                _turtle = _turtle.Next;

                if (_rabbit == _turtle)
                    break;
            }

            // 4
            rabbitPace = GetRabbitPace(RabbitPace.HaveRest);
            while (true)
            {
                _rabbit = rabbitPace(_rabbit);
                _turtle = _turtle.Next;

                if (_turtle.Next == _rabbit)
                    return _turtle;
            }


        }

        private Func<Item, Item> GetRabbitPace(RabbitPace pace)
        {
            switch (pace)
            {
                case RabbitPace.FirstRun:
                    return item => item?.Next?.Next;
                case RabbitPace.SecondRun:
                    return item => item?.Next;
                default:
                    return item => item;
            }
        }

        enum RabbitPace
        {
            FirstRun,
            SecondRun,
            HaveRest
        }
    }
}
