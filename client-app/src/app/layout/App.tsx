import React, { useEffect, Fragment, useContext } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from '../../features/nav/NavBar';
import AcitivityDashboard from '../../features/activities/dashboard/AcitivityDashboard';
import LoadingComponent from './LoadingComponent';
import ActivityStore from '../stores/activityStore';
import { observer } from 'mobx-react-lite'

const App = () => {
  const activityStore = useContext(ActivityStore);

  useEffect((() => {
    activityStore.loadActivities();
  }), [activityStore]);

  if (activityStore.loadingInitial) return <LoadingComponent content='Loading Activities...' />

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <AcitivityDashboard />
      </Container>
    </Fragment>
  );
}

export default observer(App);
