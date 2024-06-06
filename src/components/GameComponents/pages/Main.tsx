import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Card } from '../Types';

import '../Table.css';

import BattleFieldComponent from '../gcomponents/BattleFieldComponent';
import HisCardsComponents from '../gcomponents/HisCardsComponent';
import MyCardsComponents from '../gcomponents/MyCardsComponent';
import { battleField, hisCards, myCards, game } from '../store/index';

import GameOver from '../gcomponents/GameOver';

const Main: React.FC = observer(() => {
    const startGame = () => {
        const { firstHisCards, firstMyCards } = game.startGame();
        hisCards.addCards(firstHisCards);
        myCards.addCards(firstMyCards);
    };

    useEffect(startGame, []);

    const hisAction = () => {
        if (!game.isMyStep) {
            const battleFieldCards = [...battleField.cards.his, ...battleField.cards.my];

            const cardForAttack = hisCards.defineCardForAction(hisCards.cards);

            if (cardForAttack) {
                battleField.addHisCard(cardForAttack);
            }
        }
    };

    useEffect(hisAction, [game.isMyStep]);

    const clickMyCard = (card: Card) => {
        if (game.isMyStep) {
            const myStepCard = myCards.checkMyStep(card);
            if (myStepCard) {
                battleField.addMyCard(myStepCard);
            }
        }
    };

    const clearBatleField = () => {
        if (!myCards.cards.length && hisCards.cards.length)
            battleField.clearBattleField(battleField.cards.my, battleField.cards.his);
    };

    return (
        <>
            {' '}
            <main className='Main'>
                <HisCardsComponents cards={hisCards.cards} />
                <BattleFieldComponent cards={battleField.cards} />
                <MyCardsComponents cards={myCards.cards} onAtack={clickMyCard} />

                <GameOver
                    isShow={!myCards.cards.length && !hisCards.cards.length}
                    isMyWin={!myCards.cards.length}
                    onRestartGame={startGame}
                />
            </main>
        </>
    );
});

export default Main;
