import { action, makeObservable, observable } from 'mobx';
import { Card, TypeCard } from '../Types';
import { game } from '.';
import PlayerCards from './PlayerCards';

class HisCards extends PlayerCards {
    cards: Array<Card> = [];

    constructor() {
        super();

        makeObservable(this, {
            cards: observable,
            defineCardForAttack: action,
        });
    }

    defineCardForAction = (battleFieldCards: Card[]) => {
        if (!game.isMyStep) return this.defineCardForAttack(battleFieldCards);
    };

    defineCardForAttack = (battleFieldCards: Card[]) => {
        if (this.cards.length) {
            let cardForAttack = this.cards[0];

            const myCards = this.cards;

            myCards.forEach((element) => {
                if (element.points > cardForAttack.points) cardForAttack = element;
            });

            game.setAttackCardZombie(cardForAttack);
            this.reduceCard(cardForAttack.id);
            return cardForAttack;
        }
    };
}

export default new HisCards();
