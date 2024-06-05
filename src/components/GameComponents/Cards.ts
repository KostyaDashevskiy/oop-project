import { Card, TypeCard } from './Types';

//import imgh as string from '../Assets/cards img/p-sunflower.png';

export const cards: Array<Card> = [
    // 9 - растения 1 - щиты
    { id: 911, points: 40, type: TypeCard.shield, img: 'cards img/p-sunflower.png' },
    { id: 912, points: 35, type: TypeCard.shield, img: 'cards img/p-aloe.png' },
    { id: 913, points: 45, type: TypeCard.shield, img: 'cards img/p-flower.png' },
    { id: 914, points: 20, type: TypeCard.shield, img: 'cards img/p-marigold.png' },
    { id: 915, points: 60, type: TypeCard.shield, img: 'cards img/p-star.png' },

    // 9 - растения 2 - урон
    { id: 921, points: 35, type: TypeCard.damage, img: 'cards img/p-jalapeno.png' },
    { id: 922, points: 25, type: TypeCard.damage, img: 'cards img/p-wall-nut.png' },
    { id: 923, points: 30, type: TypeCard.damage, img: 'cards img/p-squash.png' },
    { id: 924, points: 30, type: TypeCard.damage, img: 'cards img/p-potato-mine.png' },
    { id: 925, points: 35, type: TypeCard.damage, img: 'cards img/p-jalapeno.png' },
    { id: 926, points: 15, type: TypeCard.damage, img: 'cards img/p-garlic.png' },
    { id: 927, points: 45, type: TypeCard.damage, img: 'cards img/p-doom-shroom.png' },
    { id: 927, points: 25, type: TypeCard.damage, img: 'cards img/p-chomper.png' },

    // 9 - растения 3 - снайперы
    { id: 931, points: 40, type: TypeCard.sniper, img: 'cards img/p-cattail.png' },
    { id: 932, points: 30, type: TypeCard.sniper, img: 'cards img/p-cabbage-pult.png' },
    { id: 933, points: 25, type: TypeCard.sniper, img: 'cards img/p-cactus.png' },
    { id: 934, points: 30, type: TypeCard.sniper, img: 'cards img/p-dusk-lobber.png' },
    { id: 935, points: 30, type: TypeCard.sniper, img: 'cards img/p-melon-pult.png' },
    { id: 936, points: 20, type: TypeCard.sniper, img: 'cards img/p-pea-pod.png' },
    { id: 937, points: 10, type: TypeCard.sniper, img: 'cards img/p-peashooter.png' },
    { id: 938, points: 15, type: TypeCard.sniper, img: 'cards img/p-snow-pea.png' },

    // 7 - зомби 1 - щиты
    { id: 711, points: 15, type: TypeCard.shield, img: 'cards img/z-flag.png' },
    { id: 712, points: 40, type: TypeCard.shield, img: 'cards img/z-box.png' },
    { id: 713, points: 50, type: TypeCard.shield, img: 'cards img/z-car.png' },
    { id: 714, points: 25, type: TypeCard.shield, img: 'cards img/z-door.png' },
    { id: 715, points: 40, type: TypeCard.shield, img: 'cards img/z-football.png' },
    { id: 716, points: 20, type: TypeCard.shield, img: 'cards img/z-ladder.png' },

    // 7 - зомби 2 - урон
    { id: 721, points: 30, type: TypeCard.damage, img: 'cards img/z-knight.png' },
    { id: 722, points: 30, type: TypeCard.damage, img: 'cards img/z-bucket.png' },
    { id: 723, points: 15, type: TypeCard.damage, img: 'cards img/z-creep.png' },
    { id: 724, points: 25, type: TypeCard.damage, img: 'cards img/z-disco.png' },
    { id: 725, points: 25, type: TypeCard.damage, img: 'cards img/z-duck.png' },
    { id: 726, points: 50, type: TypeCard.damage, img: 'cards img/z-giant.png' },
    { id: 727, points: 25, type: TypeCard.damage, img: 'cards img/z-newspaper.png' },

    // 7 - зомби 3 - снайперы
    { id: 731, points: 25, type: TypeCard.sniper, img: 'cards img/z-slingshot.png' },
    { id: 732, points: 35, type: TypeCard.sniper, img: 'cards img/z-basketball.png' },
    { id: 733, points: 30, type: TypeCard.sniper, img: 'cards img/z-bow.png' },
    { id: 734, points: 30, type: TypeCard.sniper, img: 'cards img/z-jetpack.png' },
    { id: 735, points: 35, type: TypeCard.sniper, img: 'cards img/z-jumper.png' },
    { id: 736, points: 40, type: TypeCard.sniper, img: 'cards img/z-robot.png' },
    { id: 737, points: 15, type: TypeCard.sniper, img: 'cards img/z-string.png' },
];
