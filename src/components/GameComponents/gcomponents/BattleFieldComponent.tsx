import { observer } from 'mobx-react-lite';
import * as React from 'react';
import { fieldsCard } from '../Types';
import CardComponent from './CardComponent';

interface IBattleFieldComponentProps {
    cards: fieldsCard;
}

const BattleFieldComponent: React.FC<IBattleFieldComponentProps> = observer(({ cards }) => {
    return (
        <div className='battleField'>
            <div className='iner_battleField'>
                {cards.his[2].map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='iner_battleField'>
                {cards.his[1].map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='iner_battleField'>
                {cards.his[0].map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='iner_battleField'>
                {cards.my[0].map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='iner_battleField'>
                {cards.my[1].map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='iner_battleField'>
                {cards.my[2].map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
        </div>
    );
});

export default BattleFieldComponent;
