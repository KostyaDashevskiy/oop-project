import { action, makeObservable, observable } from 'mobx';
import { game } from '.';
import { Card, fieldsCard } from '../Types';

class BattleField {
    myShield: Array<Card> = []; // Card[]; ????
    myDamage: Array<Card> = [];
    mySniper: Array<Card> = [];
    hisShield: Array<Card> = [];
    hisDamage: Array<Card> = [];
    hisSniper: Array<Card> = [];
    cards: fieldsCard = {
        my: [this.myShield, this.myDamage, this.mySniper],
        his: [this.hisShield, this.hisDamage, this.hisSniper],
    };

    constructor() {
        makeObservable(this, {
            cards: observable,
            addMyCard: action,
            addHisCard: action,
        });
    }

    addMyCard = (card: Card) => {
        if (card.type === 'shield') this.cards.my[0].push(card);
        else if (card.type === 'damage') this.cards.my[1].push(card);
        else if (card.type === 'sniper') this.cards.my[2].push(card);

        game.toggleStep();
    };

    addHisCard = (card: Card) => {
        if (card.type === 'shield') this.cards.his[0].push(card);
        else if (card.type === 'damage') this.cards.his[1].push(card);
        else if (card.type === 'sniper') this.cards.his[2].push(card);
        game.toggleStep();
    };

    clearBattleField<T, K>(myCards: T, hisCards: K) {
        this.cards.my = [];
        this.cards.his = [];
    }
}

export default new BattleField();
