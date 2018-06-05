﻿using WindowsFormsApplication1кп20.Utils;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class RulesPresenter : PresenterBase
    {
        public string Rules { get; set; }

        public RulesPresenter(ISecurityManager securityManager) : base(securityManager)
        {
            Rules =
                "Игра имеет единственное правильное решение. Есть различные уровни сложности: простую головоломку, с большим количеством заполненных клеток, можно решить за несколько минут. На сложную,  где расставлено малое количество цифр, можно потратить несколько часов. В некоторых клетках уже находятся произвольные цифры (от 1 до 9) их называют подсказки. Задача состоит в том, что бы заполнить пустые клеточки цифрами от 1 до 9 таким образом, что бы они не повторялись ни по горизонтальной линии  ни по вертикальной и не было повтора в основном квадрате (9 на 9).Вся суть решения игры «Судоку»  зависит не от расставленных произвольно цифр, а от метода и просчета дальнейших ходов. Хорошо составленная головоломка имеет только одно решение, в легких вариантах может быть несколько.";

        }

    }
}
