import React, { useContext } from 'react'
import { Card, Image, Segment, Button } from 'semantic-ui-react';
import ActivityStore from '../../../app/stores/activityStore';
import { observer } from 'mobx-react-lite';

export const ActivityDetails: React.FC = () => {

    const activityStore = useContext(ActivityStore);
    const { selectedActivity: activity, openEditForm, cancelSelectedActivity } = activityStore;

    return (
        <Segment clearing>
            <Card fluid>
                <Image src={`/assets/categoryImages/${activity!.category}.jpg`} wrapped ui={false} />
                <Card.Content>
                    <Card.Header>{activity!.title}</Card.Header>
                    <Card.Meta>
                        <span>{activity!.date}</span>
                    </Card.Meta>
                    <Card.Description>
                        {activity!.description}
                    </Card.Description>
                </Card.Content>
                <Card.Content extra>
                    <Button.Group widths={2}>
                        <Button onClick={() => openEditForm(activity!.id)}
                            basic 
                            color='blue'
                            content='Edit' />
                        <Button 
                            onClick={cancelSelectedActivity}
                            basic 
                            color='grey'
                            content='Cancel' />
                    </Button.Group>
                </Card.Content>
            </Card>
        </Segment>
    );
};

export default observer(ActivityDetails);
