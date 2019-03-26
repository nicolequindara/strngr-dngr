import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import React from 'react';

export default props => (
  <div>
    <NavMenu />
    <Container>
      {props.children}
    </Container>
  </div>
);