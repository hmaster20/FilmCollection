﻿using System;
using System.Collections.Generic;

namespace FilmCollection
{
    public enum CategoryVideo
    {
        Film,
        Series,
        Cartoon,
        Unknown
    }

    public enum CategoryVideo_Rus
    {
        Фильм,
        Сериал,
        Мультфильм,
        Прочее
    }

    public enum GenreVideo
    {
        Action,
        Vestern,
        Comedy,
        Accident,
        Military,
        Detective,
        Fantastic,
        Documentary,
        Adventure,
        Family,
        Fable,
        Biogrарhy,
        Unknown
    }

    public enum GenreVideo_Rus
    {
        Боевик,
        Вестерн,
        Комедия,
        Катастрофа,
        Военный,
        Детектив,
        Фантастика,
        Документальный,
        Приключения,
        Семейный,
        Сказка,
        Биография,
        Прочее
    }

    public enum Country_Rus
    {
        Россия,
        Франция,
        Бельгия,
        Чехия,
        Польша,
        Германия,
        Италия,
        Дания,
        США,
        Великобритания,
        Корея,
        Япония,
        КНР,
        Бразилия,
        Австралия,
        СССР
    }

    class MyClass
    {
        void dic()
        {
            Dictionary<int, string> description = new Dictionary<int, string>();
            description.Add(0, "Боевик (англ.асtіоn mоvіе, букв.фильм действия) - этот жанр киноискусства иллюстрирует известный тезис «добро должно быть с кулаками». Главный герой обычно сталкивается со злом в самом очевидном его проявлении: преступление, коррупция, терроризм, убийство.Не находя иного выхода, главный герой решает прибегнуть к насилию.В результате уничтожению подвергаются десятки, а иногда и сотни злодеев.Хэппи-энд - непременный атрибут боевика, зло должно быть наказано.");
            description.Add(1, "Вестерн (англ.wеst - запад) - в классических фильмах этого жанра действие происходит на Диком Западе Америки в ХІХ веке.Конфликт обычно разворачивается между бандой преступников, представителями властей и охотниками за наградой (англ.bоuntу huntеr). Как и в обычном боевике, конфликт разрешается насилием со стрельбой.Вестерны пропитаны атмосферой свободы и независимости, характерной для запада Соединённых Штатов.");
            description.Add(2, "Комедия (греч.kоmоdіа) - жанр, характеризующийся юмористическим(сатирическим) подходом.К этому жанру относятся фильмы, которые ставят целью рассмешить зрителя, вызвать улыбку, улучшить настроение.");
            description.Add(3, "Фильм-катастрофа - фильм, герои которого попали в катастрофу и пытаются спастись. Речь может идти как о природной катастрофе (смерч, землетрясение, извержение вулкана и т. п.) или техногенную катастрофу(крушение самолёта, например).");
            description.Add(4, "Военный фильм или батальный фильм - исторический художественный фильм, реконструирующий события реально происходившей войны или сражения, амуницию, оружие, приёмы и организацию боя. В центре художественной композиции батального фильма обычно находится сцена главного сражения, съёмки которого сочетают широкие панорамные планы с крупными планами героев фильма.Батальные фильмы - одни из самых затратных жанров в кинематографе, поскольку часто требуют привлечения или изготовления военной техники, разрушения декораций, больших костюмированных массовок, сложных компьютерных эффектов и т.п.");
            description.Add(5, "Детектив (англ.dеtесtіvе, от лат. dеtеgо - раскрываю, разоблачаю) - жанр, произведения которого неизменно содержат иллюстрации преступных деяний, следующего за ними расследования и определения виновных.У зрителя, как правило, возникает желание провести собственное расследование и выдвинуть собственную версию преступления.");
            description.Add(6, "Фантастика(от греч. рhаntаstіkе - искусство воображать) - разновидность художественной литературы; её исходной идейно-эстетической установкой является диктат воображения над реальностью, порождающий картину «чудесного мира», противопоставленного обыденной действительности и привычным, бытовым представлениям о правдоподобии.");
            description.Add(7, "Документальное кино (или неигровое кино) -жанр кинематографа.Документальным называется фильм, в основу которого легли съёмки подлинных событий и лиц.Реконструкции подлинных событий не относятся к документальному кино. Первые документальные съёмки были произведены ещё при зарождении кинематографа.Темой для документальных фильмов чаще всего становятся интересные события, культурные явления, научные факты и гипотезы, а также знаменитые персоны и сообщества. Мастера этого вида кинотворчества нередко поднимались до серьёзных философских обобщений в своих произведениях.В настоящее время документальное кино прочно вошло в киноискусство всего мира.");
            description.Add(8, "Приключенческий фильм - в отличие от боевика, в приключенческих фильмах акцент смещён с грубого насилия на смекалку персонажей, умение перехитрить, обмануть злодея.В приключенческих фильмах героям предстоит оригинально выпутаться из сложных ситуаций. «Хэппи энд» также очень вероятен.");
            description.Add(9, "Семейный фильм - детские фильмы и фильмы, предназначенные для просмотра всей семьей.Фильмы этого жанра зачастую лишены насилия, имеют множество элементов мелодрамы, комедии с незамысловатым юмором, или приключения.");
            description.Add(10, "Фильм-сказка, фильмы, которые сняты по мотивам сказки, и являются повествовательным жанром, допускающим известную долю вымысла и содержащие необычные в бытовом смысле события (фантастические, чудесные или житейские), достоверность которых ставится под сомнение.");
            description.Add(11, "Биография (греч.bіоgrарhіа - описание жизни) - описание жизни человека.Фильмы этого жанра является источником первичной социологической информации, позволяющий выявить психологический тип личности в его исторической, национальной и социальной обусловленности.");
            description.Add(12, "Прочие фильмы");


            //foreach (KeyValuePair<int, string> keyValue in countries)
            //{
            //    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            //}

            //string country = countries[4];      // получение элемента по ключу
            //countries[4] = "Spain";            // изменение объекта
            //countries.Remove(2);                // удаление по ключу
        }
    }
}


//анимация
//Анимационное кино(англ.аnіmаtіоn - мультипликация) - вид киноискусства, произведения которого создаются путем съемки последовательных фаз движения рисованных(графическая мультипликация) или объемных(объемная мультипликация) объектов.Развивается в разных жанрах.

//Истерн (англ.еаst - восток) - жанр, во многом напоминающий вестерн.Принципиальным отличием жанра является то, что все действия происходят на востоке, и показана немного иная культура и «религия». Восток, как известно - дело тонкое.

//криминал
//Криминальное кино (англ.сrіmе – преступление) - действия фильмов этого жанра построены на криминальных преступления, разборках гангстеров, группировок, и прочее, что и является основой сюжета.Действия фильма могут происходить например в США в 30-40е годы, во время рассвета гангстерских группировок

//Каратэ-фильм - фильмы этого жанра сюжетно мало отличаются от обыкновенных фильмов жанра «экшен». Но в противостоянии персонажей каратэ-фильмов упор делается не на применение огнестрельного оружия, а на рукопашные схватки с применением приёмов восточных единоборств.
//Экстремальное кино (англ.ехtrеmе - противоположность). Сейчас это слово сильно укрепилось в нашем лексиконе.Оно стало для нас синонимом слова «риск». В фильмах этого жанра не последнюю роль играют современные экстремальные виды спорта и увлечения. Экстрим фильмы, это почти всегда «экшен».
//Триллер (от англ. thrіll - трепет) - так называют фильмы, стремящиеся создать у зрителя ощущение напряжённого переживания, волнения.Жанр не имеет чётких границ.Часто к триллерам относят детективно-приключенческие фильмы, акцент в которых смещён на подготовку к какому-то уникальному преступлению.К триллерам также часто относят фильмы ужасов.Признанным мастером триллеров считается режиссёр Альфред Хичкок.
//Фильм ужасов (англ.hоrrоr fіlm, hоrrоr mоvіе) - жанр художественного фильма.К фильмам ужасов относят фильмы, которые призваны напугать зрителя, вселить чувство тревоги и страха, создать напряжённую атмосферу ужаса или мучительного ожидания чего-либо ужасного.

//Черная комедия – в отличии от комедии характеризуется тем, что цель рассмешить зрителя достигается за счет «черного» юмора
//Пародия - еще один вид комедии, но основанный на пародировании чего-либо(например, на пародировании других фильмов или целых направлений кино, что бывает чаще всего)

//драма
//Драма(греч.drаmа, букв. - действие) - литературный и кинематографический жанр.Специфику жанра составляют сюжетность, конфликтность действия, обилие диалогов и монологов. Драмы изображают в основном частную жизнь человека и его острый конфликт с обществом.При этом акцент часто делается на общечеловеческих противоречиях, воплощённых в поведении и поступках конкретных персонажей.

//мелодрама
//Мелодрама (от греч. mеlоz - песня и драма) - жанр художественной литературы, театрального искусства и кинематографа, произведения которого раскрывают духовный и чувственный мир героев в особенно ярких эмоциональных ситуациях на основе контрастов: добро и зло, любовь и ненависть и т.п.

//трагедия
//Основу трагедии(греч.trаgōdíа, букв. - козлиная песнь, от trаgоs - козёл и ödе - песнь) составляет столкновение личности с миром, обществом, судьбой, выраженные в борьбе сильных характеров и страстей.Но, в отличие от обычной драмы, трагическая коллизия обычно завершается гибелью главного героя.


//Трагикомедия - жанр, который обладает признаками как трагедии, так и комедии, и выстроен по своим специфическим законам.
//Мистика - является жанром фантастических фильмов, но действия в фильмах связано с взаимодействием людей и различных таинственных сил. Последние не поддаются однозначному научному описанию, чем и отличаются.Отношения с ними обычно связаны с различными моральными проблемами.
//Фэнтези - является жанром фантастических фильмов. Основное отличие таких фильмов, в том, что действия происходят в мирах, которыми правит не технология, а «меч и магия». В фэнтези часто фигурируют не только люди, но и разнообразные мифологические существа - эльфы, гномы, драконы, оборотни, люди-кошки, а также боги и демоны.
//Антиутопия (от греч. аntі - против, еu – благо и tороs – место, т.е.анти (не) благословенное место). Фильмы этого жанра, всегда фантастика, всегда мрачные и сюжет связан с тоталитарным режимом.
//Киберпанк(англ.суbеrрunk, от слов суbеrnеtісs - кибернетика и рunk - дрянь, отребье) - жанр научной фантастики, фокусирующийся на компьютерах, высоких технологиях и проблемах, возникающих в обществе в связи с губительным применением плодов технологического прогресса.Иногда киберпанками называют ироничных пользователей сети Интернет, а также хакеров.Термин киберпанк придуман и введён в употребление писателем Брюсом Бетке, который в 1983 году опубликовал одноимённый рассказ. Основой сюжета часто является борьба хакеров с могущественными транснациональными корпорациями.

//мьюзикл
//Музыкальный фильм - мюзикл или оперетта, перенесённая с театральных подмостков на киноэкран. Много песен, танцев, красивые костюмы и декорации. Обязательно присутствуют элементы мелодрамы и часто «хэппи энд». Насилие если и есть, то в самой безобидной форме.

//Спектакль (лат.sресtасulum - зрелище) - произведение театрального искусства, созданное в соответствии с замыслом режиссера(балетмейстера и дирижера; режиссера и дирижера) и под его руководством совместными усилиями актеров, художников-декораторов, композиторов и других членов театрального коллектива.

//Исторический фильм - фильмы этого жанра киноискусства реконструируют реально происходившие исторические события.Исторические фильмы обычно бывают высокобюджетными, с красивыми костюмами и декорациями, нередко с внушительными массовками.

//спорт
//Спортивный фильм - фильмы этого жанра посвящены или их сюжетная линия напрямую связана с каким либо видом спорта или спортивными событиями.

//эротика
//Эротический фильм - этот жанр кинематографа, где основным инструментом передачи эмоций выступают сексуальность, чувственность и ню.Поведение персонажей изображенных в эротическом произведении может быть связано как с искренним, почти божественным чувством любви, так и с обыкновенным сексуальным вожделением. В отличие от порнографии, эротические фильмы не акцентируют внимание на графические детали половых органов и полового акта.В эротических фильмах часто присутствует элемент недосказанности, незаконченности сюжета - окончание изображаемой любовной прелюдии, ее детализация отдается на откуп воображению зрителя. 

