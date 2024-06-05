import * as React from 'react';
import { Card } from '../Types';
import CardComponent from '../gcomponents/CardComponent';

interface IHisCardsComponentsProps {
    cards: Card[];
}

const HisCardsComponents: React.FC<IHisCardsComponentsProps> = ({ cards }) => {
    return (
        <div className='playerCards'>
            {cards.map((card) => (
                <CardComponent key={card.id} card={card} />
            ))}
        </div>
    );
};

export default HisCardsComponents;
