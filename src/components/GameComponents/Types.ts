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
    my: Array<Array<Card>>;
    his: Array<Array<Card>>;
}
