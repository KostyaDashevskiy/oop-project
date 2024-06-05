export enum TypeCard {
    shield = 'shield',
    damage = 'damage',
    sniper = 'sniper',
}

export interface Card {
    id: number;
    points: number;
    type: TypeCard;
    img: string;
}
/*
export interface CoupleCard {
    my: Card[];
    his: Card[];
}
*/
export interface fieldsCard {
    myShield: Array<Card>; // Card[]; ????
    myDamage: Array<Card>;
    mySniper: Array<Card>;
    hisShield: Array<Card>;
    hisDamage: Array<Card>;
    hisSniper: Array<Card>;
}
