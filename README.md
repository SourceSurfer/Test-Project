# Тестовое задание
#### Разработать консольное .NET приложение для склада

 - Построить иерархию классов, описывающих объекты на складе - паллеты и коробки:
1. Помимо общего набора стандартных свойств (ID, ширина, высота, глубина, вес), паллета может содержать в себе коробки.
2. У коробки должен быть указан срок годности или дата производства. Если указана дата производства, то срок годности вычисляется из даты производства плюс 100 дней.
3. Срок годности и дата производства — это конкретная дата без времени (например, 01.01.2023).
4. Срок годности паллеты вычисляется из наименьшего срока годности коробки, вложенный в паллет. Вес паллеты вычисляется из суммы веса вложенных коробок + 30кг.
5. Объем коробки вычисляется как произведение ширины, высоты и глубины.
6. Объем паллеты вычисляется как сумма объема всех находящихся на ней коробок и произведения ширины, высоты и глубины паллеты.
7. Каждая коробка не должна превышать по размерам паллету (по ширине и глубине).

------------

#### Консольное приложение
- Получение данных для приложения: Пользовательский ввод

------------

#### Вывести на экран
- Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.
- 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.

#### Пример пользовательского ввода
[![imageup.ru](https://imageup.ru/img50/4402491/screenshot-2023-06-27-195606.png)](https://imageup.ru/img50/4402491/screenshot-2023-06-27-195606.png.html)

