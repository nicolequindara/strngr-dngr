import { Container } from 'reactstrap';
import React from 'react';

export default props => (
  <div>
    <Container>
      {props.children}
    </Container>
  </div>
);
