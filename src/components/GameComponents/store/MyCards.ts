import { makeObservable, observable } from 'mobx';
import { Card } from '../Types';
import { game } from '.';
import PlayerCards from './PlayerCards';

class MyCards extends PlayerCards {
    cards: Array<Card> = [];

    constructor() {
        super();

        makeObservable(this, {
            cards: observable,
        });
    }

    checkMyStep(card: Card) {
        if (game.isMyStep) {
            return this.myAttack(card);
        }
    }

    myAttack(card: Card) {
        game.setAttackCardPlants(card);
        this.reduceCard(card.id);
        return card;
    }
}

export default new MyCards();
